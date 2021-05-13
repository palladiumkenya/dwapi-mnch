using System;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData.Interfaces;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData.Models;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Mnch.SharedKernel.Infrastructure.Tests.TestData
{

    public class TestCarRepository :BaseRepository<TestCar,Guid>,  ITestCarRepository
    {
        public TestCarRepository(DbContext context) : base(context)
        {
        }
    }
}
