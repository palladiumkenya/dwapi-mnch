﻿using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.Infrastructure.Data;
using Dwapi.Mnch.Infrastructure.Data.Repository;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Dwapi.Mnch.Infrastructure.Tests.Data.Repository
{
    [TestFixture]
    [Category("UsesDb")]
    public class FacilityRepositoryTests
    {
        private ServiceProvider _serviceProvider;
        private MnchContext _context;
        private List<Facility> _facilities;
        private IFacilityRepository _facilityRepository;
        private List<Manifest> _manifests;

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config["ConnectionStrings:DwapiConnection"];

            _serviceProvider = new ServiceCollection()
                .AddDbContext<MnchContext>(o => o.UseSqlServer(connectionString))
                .AddTransient<IFacilityRepository, FacilityRepository>()
                .AddTransient<IManifestRepository, ManifestRepository>()
                .BuildServiceProvider();

            _facilities = TestDataFactory.TestFacilityWithPatients(2);
            _manifests = TestDataFactory.TestManifests(2);

            _manifests[0].FacilityId = _facilities[0].Id;
            _manifests[1].FacilityId = _facilities[1].Id;

            _context = _serviceProvider.GetService<MnchContext>();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.MasterFacilities.AddRange(TestDataFactory.TestMasterFacilities());
            _context.Facilities.AddRange(_facilities);
            _context.Manifests.AddRange(_manifests);
            _context.SaveChanges();
        }

        [SetUp]
        public void Setup()
        {
            _facilityRepository = _serviceProvider.GetService<IFacilityRepository>();
        }

        [Test]
        public void should_Clear_With_Manifest_Facility()
        { var stats= _facilityRepository.GetFacStats(_facilities[0].Id);
            Assert.NotNull(stats);
        }


    }
}
