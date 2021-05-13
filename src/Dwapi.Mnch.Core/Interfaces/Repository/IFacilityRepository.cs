using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Exchange;
using Dwapi.Mnch.SharedKernel.Interfaces;
using Dwapi.Mnch.SharedKernel.Model;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IFacilityRepository : IRepository<Facility, Guid>
    {
        IEnumerable<SiteProfile> GetSiteProfiles();
        IEnumerable<SiteProfile> GetSiteProfiles(List<int> siteCodes);

        IEnumerable<StatsDto> GetFacStats(IEnumerable<Guid> facilityIds);
        StatsDto GetFacStats(Guid facilityId);
        Facility GetBySiteCode(int siteCode);
    }
}
