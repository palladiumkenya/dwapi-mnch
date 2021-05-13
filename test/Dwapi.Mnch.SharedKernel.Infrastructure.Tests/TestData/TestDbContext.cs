using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData.Models;
using EFCore.Seeder.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Mnch.SharedKernel.Infrastructure.Tests.TestData
{
    public class TestDbContext:BaseContext
    {
        public DbSet<TestCar> TestCars { get; set; }
        public DbSet<TestModel> TestModels { get; set; }

        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        public override void EnsureSeeded()
        {
            TestCars.SeedDbSetIfEmpty($"{nameof(TestCar)}");
            TestModels.SeedDbSetIfEmpty($"{nameof(TestModel)}");
            base.EnsureSeeded();
        }
    }
}
