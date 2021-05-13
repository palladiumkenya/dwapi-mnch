using System;
using Dwapi.Mnch.SharedKernel.Interfaces;
using Dwapi.Mnch.SharedKernel.Tests.TestData.TestData.Models;

namespace Dwapi.Mnch.SharedKernel.Tests.TestData.TestData.Interfaces
{
    public interface ITestCarRepository : IRepository<TestCar,Guid>
    {

    }
}
