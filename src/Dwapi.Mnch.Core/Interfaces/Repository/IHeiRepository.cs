using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IHeiRepository : IRepository<Hei,Guid>{void Process(Guid facilityId,IEnumerable<Hei> clients);}
}