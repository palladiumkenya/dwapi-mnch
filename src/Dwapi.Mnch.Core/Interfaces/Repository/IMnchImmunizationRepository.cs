using System;
using System.Collections.Generic;
using Dwapi.ExtractsManagement.Core.Model.Destination.Mnch;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IMnchImmunizationRepository : IRepository<MnchImmunization,Guid>{void Process(Guid facilityId,IEnumerable<MnchImmunization> clients);}
}