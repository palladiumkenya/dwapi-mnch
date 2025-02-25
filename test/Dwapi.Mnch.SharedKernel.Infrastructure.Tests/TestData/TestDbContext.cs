﻿using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData.Models;
using Dwapi.Mnch.SharedKernel.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
            if (!TestCars.Any())
            {
                var data = SeedDataReader.ReadCsv<TestCar>(typeof(TestDbContext).Assembly,"Seed","|");
                TestCars.AddRange(data);
            }

            if (!TestModels.Any())
            {
                var data = SeedDataReader.ReadCsv<TestModel>(typeof(TestDbContext).Assembly,"Seed","|");
                TestModels.AddRange(data);
            }

            base.EnsureSeeded();
        }
    }
}
