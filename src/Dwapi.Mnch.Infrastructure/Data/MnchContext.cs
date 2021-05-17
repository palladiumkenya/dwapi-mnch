using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Dwapi.Mnch.SharedKernel.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Serilog;
using Z.Dapper.Plus;

namespace Dwapi.Mnch.Infrastructure.Data
{
    public class MnchContext : BaseContext
    {
        public DbSet<Docket> Dockets { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<MasterFacility> MasterFacilities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }

        public DbSet<PatientMnch> MnchPatients { get; set; }
        public DbSet<MnchEnrolment> MnchEnrolments { get; set; }
        public DbSet<MnchArt> MnchArts { get; set; }
        public DbSet<AncVisit> AncVisits { get; set; }
        public DbSet<MatVisit> MatVisits { get; set; }
        public DbSet<PncVisit> PncVisits { get; set; }
        public DbSet<MotherBabyPair> MotherBabyPairs { get; set; }
        public DbSet<CwcEnrolment> CwcEnrolments { get; set; }
        public DbSet<CwcVisit> CwcVisits { get; set; }
        public DbSet<Hei> Heis { get; set; }
        public DbSet<MnchLab> MnchLabs { get; set; }

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

            DapperPlusManager.Entity<PatientMnch>().Key(x => x.Id).Table($"{nameof(MnchContext.MnchPatients)}");
            DapperPlusManager.Entity<MnchEnrolment>().Key(x => x.Id).Table($"{nameof(MnchContext.MnchEnrolments)}");
            DapperPlusManager.Entity<MnchArt>().Key(x => x.Id).Table($"{nameof(MnchContext.MnchArts)}");
            DapperPlusManager.Entity<AncVisit>().Key(x => x.Id).Table($"{nameof(MnchContext.AncVisits)}");
            DapperPlusManager.Entity<MatVisit>().Key(x => x.Id).Table($"{nameof(MnchContext.MatVisits)}");
            DapperPlusManager.Entity<PncVisit>().Key(x => x.Id).Table($"{nameof(MnchContext.PncVisits)}");
            DapperPlusManager.Entity<MotherBabyPair>().Key(x => x.Id).Table($"{nameof(MnchContext.MotherBabyPairs)}");
            DapperPlusManager.Entity<CwcEnrolment>().Key(x => x.Id).Table($"{nameof(MnchContext.CwcEnrolments)}");
            DapperPlusManager.Entity<CwcVisit>().Key(x => x.Id).Table($"{nameof(MnchContext.CwcVisits)}");
            DapperPlusManager.Entity<Hei>().Key(x => x.Id).Table($"{nameof(MnchContext.Heis)}");
            DapperPlusManager.Entity<MnchLab>().Key(x => x.Id).Table($"{nameof(MnchContext.MnchLabs)}");

        }

        public override void EnsureSeeded()
        {
            Log.Debug("seeding...");
            if (!MasterFacilities.Any())
            {
                var data = SeedDataReader.ReadCsv<MasterFacility>(typeof(MnchContext).Assembly,"Seed","|");
                MasterFacilities.AddRange(data);
            }

            if (!Dockets.Any())
            {
                var data = SeedDataReader.ReadCsv<Docket>(typeof(MnchContext).Assembly,"Seed","|");
                Dockets.AddRange(data);
            }

            if (!Subscribers.Any())
            {
                var data = SeedDataReader.ReadCsv<Subscriber>(typeof(MnchContext).Assembly,"Seed","|");
                Subscribers.AddRange(data);
            }
            SaveChanges();
            Log.Debug("seeding DONE");
        }
    }
}
