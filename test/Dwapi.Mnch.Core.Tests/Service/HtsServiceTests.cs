using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Dwapi.Mnch.Core.Command;
using Dwapi.Mnch.Core.CommandHandler;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.Core.Interfaces.Service;
using Dwapi.Mnch.Core.Service;
using Dwapi.Mnch.Infrastructure.Data;
using Dwapi.Mnch.Infrastructure.Data.Repository;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Z.Dapper.Plus;

namespace Dwapi.Mnch.Core.Tests.Service
{
    public class MnchServiceTests
    {
        private ServiceProvider _serviceProvider;
        private List<PatientMnch> _patientIndices;

        private List<PatientMnch> _patientIndicesSiteB;
        private MnchContext _context;
        private IMnchService _mnchService;
        private IManifestService _manifestService;
        private IMediator _mediator;

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config["ConnectionStrings:DwapiConnectionDev"];
            var liveSync = config["LiveSync"];


            DapperPlusManager.AddLicense("1755;700-ThePalladiumGroup", "2073303b-0cfc-fbb9-d45f-1723bb282a3c");
            if (!Z.Dapper.Plus.DapperPlusManager.ValidateLicense(out var licenseErrorMessage))
            {
                throw new Exception(licenseErrorMessage);
            }


            Uri endPointA = new Uri(liveSync); // this is the endpoint HttpClient will hit
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = endPointA,
            };


            _serviceProvider = new ServiceCollection()
                .AddDbContext<MnchContext>(o => o.UseSqlServer(connectionString))

                .AddScoped<IDocketRepository, DocketRepository>()
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()

                .AddScoped<IFacilityRepository, FacilityRepository>()
                .AddScoped<IManifestRepository, ManifestRepository>()
                .AddScoped<IPatientMnchRepository, PatientMnchRepository>()
                .AddScoped<IAncVisitRepository, AncVisitRepository>()


                .AddScoped<IFacilityRepository, FacilityRepository>()
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()
                .AddScoped<IPatientMnchRepository, PatientMnchRepository>()
                .AddScoped<IManifestRepository, ManifestRepository>()
                .AddScoped<IAncVisitRepository, AncVisitRepository>()


                .AddScoped<IMnchService, MnchService>()
                .AddScoped<ILiveSyncService, LiveSyncService>()
                .AddScoped<IManifestService, ManifestService>()
                .AddSingleton<HttpClient>(httpClient)
                .AddMediatR(typeof(ValidateFacilityHandler))
                .BuildServiceProvider();


            _context = _serviceProvider.GetService<MnchContext>();
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
            _context.MasterFacilities.AddRange(TestDataFactory.TestMasterFacilities());
            var facilities = TestDataFactory.TestFacilities();
            _context.Facilities.AddRange(facilities);
            _context.SaveChanges();
            _patientIndices = TestDataFactory
                .TestClients(1, facilities.First(x => x.SiteCode == 1).Id);
            _patientIndicesSiteB =
                TestDataFactory
                    .TestClients(2, facilities.First(x => x.SiteCode == 2).Id);
        }

        [SetUp]
        public void SetUp()
        {
            _manifestService = _serviceProvider.GetService<IManifestService>();
            _mediator = _serviceProvider.GetService<IMediator>();
            _mnchService = _serviceProvider.GetService<IMnchService>();
        }


        [Test]
        public void should_Process_After_Manifest()
        {
            var manifest = TestDataFactory.TestManifests(1).First();
            manifest.SiteCode = 1;
            var patients = _context.Clients.ToList();
            Assert.False(patients.Any());

            var id = _mediator.Send(new SaveManifest(manifest)).Result;
            _manifestService.Process(manifest.SiteCode);
            _mnchService.Process(_patientIndices);
            Assert.True(_context.Clients.Any(x=>x.SiteCode==1));
        }

        [Test]
        public void should_Process_Recodrds_Without_Clients()
        {
            var manifests = TestDataFactory.TestManifests();
            manifests[0].SiteCode = 1;
            manifests[1].SiteCode = 2;
            var patients = _context.Clients.ToList();
            Assert.False(patients.Any());

            var id = _mediator.Send(new SaveManifest(manifests[0])).Result;
            _manifestService.Process(manifests[0].SiteCode);
            _mnchService.Process(_patientIndices);
            Assert.True(_context.Clients.Any(x => x.SiteCode == 1));

            var id2 = _mediator.Send(new SaveManifest(manifests[1])).Result;
            _manifestService.Process(manifests[1].SiteCode);
            _mnchService.Process(_patientIndicesSiteB);
            Assert.True(_context.Clients.Any(x => x.SiteCode == 1));
            Assert.True(_context.Clients.Any(x => x.SiteCode == 2));
        }
    }
}
