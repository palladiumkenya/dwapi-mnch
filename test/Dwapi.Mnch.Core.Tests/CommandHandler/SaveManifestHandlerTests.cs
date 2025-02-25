﻿using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Command;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.Infrastructure.Data;
using Dwapi.Mnch.Infrastructure.Data.Repository;
using Dwapi.Mnch.SharedKernel.Exceptions;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Dwapi.Mnch.Core.Tests.CommandHandler
{
    [TestFixture]
    public class SaveManifestHandlerTests
    {
        private ServiceProvider _serviceProvider;
        private IMediator _mediator;
        private MnchContext _context;
        private List<Manifest> _manifests;


        [OneTimeSetUp]
        public void Init()
        {
            _serviceProvider = new ServiceCollection()
                .AddDbContext<MnchContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()
                .AddScoped<IFacilityRepository, FacilityRepository>()
                .AddScoped<IManifestRepository, ManifestRepository>()
                .AddMediatR(typeof(ValidateFacilityHandler))
                .BuildServiceProvider();

            _context = _serviceProvider.GetService<MnchContext>();
            _context.MasterFacilities.Add(new MasterFacility(1, "XFacility", "XCounty"));
            _context.MasterFacilities.Add(new MasterFacility(2, "YFacility", "YCounty"));
            _context.Facilities.Add(new Facility(1, "XFacility District", 1));
            _context.SaveChanges();

            _manifests = TestDataFactory.TestManifests(3, 2);
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = _serviceProvider.GetService<IMediator>();
        }

        [Test]
        public void should_Throw_Exception_Invalid_SiteCode_Manifest()
        {
            var manifest = _manifests[0];
            manifest.SiteCode = 3;
            manifest.Name = "XFac";

            var ex = Assert.Throws<System.AggregateException>(() => CreateManifest(manifest));
            Assert.AreEqual(typeof(FacilityNotFoundException), ex.InnerException.GetType());
            Console.WriteLine($"{ex.InnerException.Message}");
        }

        [Test]
        public void should_Create_Manifest_Enrolled_Facility()
        {
            var manifest = _manifests[1];
            manifest.SiteCode = 1;
            manifest.Name = "X Hos";
            var manifestId = CreateManifest(manifest);

            var savedManifest = _context.Manifests.Find(manifestId);
            Assert.NotNull(savedManifest);
            Assert.True(savedManifest.Cargoes.Count > 0);

            var facility = _context.Facilities.Find(savedManifest.FacilityId);
            var mflfacility = _context.MasterFacilities.Find(facility.SiteCode);
            Assert.NotNull(facility);
            Assert.NotNull(mflfacility);
            Console.WriteLine(facility);
        }

        [Test]
        public void should_Create_Manifest_New_Facility()
        {
            var manifest = _manifests[2];
            manifest.SiteCode = 2;
            manifest.Name = "Y Hos";

            var manifestId = CreateManifest(manifest);

            var savedManifest = _context.Manifests.Find(manifestId);
            Assert.NotNull(savedManifest);
            Assert.True(savedManifest.Cargoes.Count > 0);

            var facility = _context.Facilities.Find(savedManifest.FacilityId);
            var mflfacility = _context.MasterFacilities.Find(facility.SiteCode);
            Assert.NotNull(facility);
            Assert.NotNull(mflfacility);
            Console.WriteLine(facility);
        }

        private Guid CreateManifest(Manifest manifest)
        {
            return _mediator.Send(new SaveManifest(manifest)).Result;
        }
    }
}
