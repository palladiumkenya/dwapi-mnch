using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IMnchEnrolmentRepository : IRepository<MnchEnrolment,Guid>{void Process(Guid facilityId,IEnumerable<MnchEnrolment> clients);}
}