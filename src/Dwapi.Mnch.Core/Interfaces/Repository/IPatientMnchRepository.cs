using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IPatientMnchRepository : IRepository<PatientMnch,Guid>
    {
        void Process(Guid facilityId,IEnumerable<PatientMnch> clients);
    }
}
