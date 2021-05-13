using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IMotherBabyPairRepository : IRepository<MotherBabyPair,Guid>{void Process(Guid facilityId,IEnumerable<MotherBabyPair> clients);}
}