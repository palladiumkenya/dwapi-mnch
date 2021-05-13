using System.Reflection;
using CsvHelper.Configuration;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using EFCore.Seeder.Configuration;
using EFCore.Seeder.Extensions;
using Microsoft.EntityFrameworkCore;
using Z.Dapper.Plus;

namespace Dwapi.Mnch.Infrastructure.Data
{
    public class MnchContext:BaseContext
    {
        public DbSet<Docket> Dockets { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<MasterFacility> MasterFacilities { get; set; }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<PatientMnch> Clients { get; set; }
        public DbSet<AncVisit> ClientLinkages { get; set; }


        public MnchContext(DbContextOptions<MnchContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DapperPlusManager.Entity<Docket>().Key(x => x.Id).Table($"{nameof(MnchContext.Dockets)}");
            DapperPlusManager.Entity<Subscriber>().Key(x => x.Id).Table($"{nameof(MnchContext.Subscribers)}");

            DapperPlusManager.Entity<MasterFacility>().Key(x => x.Id).Table($"{nameof(MnchContext.MasterFacilities)}");

            DapperPlusManager.Entity<Facility>().Key(x => x.Id).Table($"{nameof(MnchContext.Facilities)}");
            DapperPlusManager.Entity<Manifest>().Key(x => x.Id).Table($"{nameof(MnchContext.Manifests)}");
            DapperPlusManager.Entity<Cargo>().Key(x => x.Id).Table($"{nameof(MnchContext.Cargoes)}");
            DapperPlusManager.Entity<PatientMnch>().Key(x => x.Id).Table($"{nameof(MnchContext.Clients)}");
            DapperPlusManager.Entity<AncVisit>().Key(x => x.Id).Table($"{nameof(MnchContext.ClientLinkages)}");

        }

        public override void EnsureSeeded()
        {
            var csvConfig = new Configuration()
            {
                Delimiter = "|",
                HeaderValidated = null,
                MissingFieldFound = null
            };

            SeederConfiguration.ResetConfiguration(csvConfig, null, typeof(MnchContext).GetTypeInfo().Assembly);

        //    MasterFacilities.SeedDbSetIfEmpty($"{nameof(MasterFacility)}");
            Dockets.SeedDbSetIfEmpty($"{nameof(Docket)}");
            SaveChanges();
            Subscribers.SeedDbSetIfEmpty($"{nameof(Subscriber)}");
            SaveChanges();
        }
    }
}
