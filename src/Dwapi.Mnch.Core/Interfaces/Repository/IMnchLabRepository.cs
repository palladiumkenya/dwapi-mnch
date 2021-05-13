using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IMnchLabRepository : IRepository<MnchLab,Guid>{void Process(Guid facilityId,IEnumerable<MnchLab> clients);}
}