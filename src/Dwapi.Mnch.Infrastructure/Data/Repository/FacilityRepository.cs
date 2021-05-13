using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Exchange;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Dwapi.Mnch.SharedKernel.Model;
using Serilog;

namespace Dwapi.Mnch.Infrastructure.Data.Repository
{
    public class FacilityRepository : BaseRepository<Facility, Guid>, IFacilityRepository
    {
        public FacilityRepository(MnchContext context) : base(context)
        {
        }

        public IEnumerable<SiteProfile> GetSiteProfiles()
        {
            return GetAll().Select(x => new SiteProfile(x.SiteCode, x.Id));
        }

        public IEnumerable<SiteProfile> GetSiteProfiles(List<int> siteCodes)
        {
            return GetAll(x=>siteCodes.Contains(x.SiteCode)).Select(x => new SiteProfile(x.SiteCode, x.Id));
        }

        public IEnumerable<StatsDto> GetFacStats(IEnumerable<Guid> facilityIds)
        {
            var list = new List<StatsDto>();
            foreach (var facilityId in facilityIds)
            {
                try
                {
                    var stat = GetFacStats(facilityId);
                    if(null!=stat)
                        list.Add(stat);
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                }


            }
            return list;
        }

        public StatsDto GetFacStats(Guid facilityId)
        {
            string sql = $@"
select
(select top 1 SiteCode from Facilities where id='{facilityId}') FacilityCode,
(select ISNULL(max(DateCreated),GETDATE()) from Clients where facilityid='{facilityId}') Updated,
(select count(id) from Clients where facilityid='{facilityId}') PatientMnchExtract,
(select count(id) from ClientLinkages where facilityid='{facilityId}') AncVisitExtract,
(select count(id) from PatientMnchTests where facilityid='{facilityId}') PatientMnchTestsExtract,
(select count(id) from PatientMnchTracing where facilityid='{facilityId}') PatientMnchTracingExtract,
(select count(id) from MnchPartnerNotificationServices where facilityid='{facilityId}') MnchPartnerNotificationServicesExtract,
(select count(id) from MnchPartnerTracings where facilityid='{facilityId}') MnchPartnerTracingExtract,
(select count(id) from MnchTestKits where facilityid='{facilityId}') MnchTestKitsExtract
                ";

            var result = GetDbConnection().Query<dynamic>(sql).FirstOrDefault();

            if (null != result)
            {
                var stats=new StatsDto(result.FacilityCode,result.Updated);
                stats.AddStats("PatientMnchExtract",result.PatientMnchExtract);
                stats.AddStats("AncVisitExtract",result.AncVisitExtract);
                stats.AddStats("PatientMnchTestsExtract",result.PatientMnchTestsExtract);
                stats.AddStats("PatientMnchTracingExtract",result.PatientMnchTracingExtract);
                stats.AddStats("MnchPartnerNotificationServicesExtract",result.MnchPartnerNotificationServicesExtract);
                stats.AddStats("MnchPartnerTracingExtract",result.MnchPartnerTracingExtract);
                stats.AddStats("MnchTestKitsExtract",result.MnchTestKitsExtract);

                return stats;
            }

            return null;
        }

        public Facility GetBySiteCode(int siteCode)
        {
            return DbSet.FirstOrDefault(x=>x.SiteCode==siteCode);
        }
    }
}
