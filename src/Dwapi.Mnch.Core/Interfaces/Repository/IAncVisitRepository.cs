using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IAncVisitRepository : IRepository<AncVisit,Guid>
    {
        void Process(Guid facilityId,IEnumerable<AncVisit> clients);
    }
}
