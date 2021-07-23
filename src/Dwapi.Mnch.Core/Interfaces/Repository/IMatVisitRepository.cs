using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IMatVisitRepository : IRepository<MatVisit,Guid>{void Process(Guid facilityId,IEnumerable<MatVisit> clients);}
}