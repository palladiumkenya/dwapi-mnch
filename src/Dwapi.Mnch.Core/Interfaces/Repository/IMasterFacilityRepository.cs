using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IMasterFacilityRepository:IRepository<MasterFacility,int>
    {
        MasterFacility GetBySiteCode(int siteCode);
        List<MasterFacility> GetLastSnapshots(int siteCode);
    }
}
