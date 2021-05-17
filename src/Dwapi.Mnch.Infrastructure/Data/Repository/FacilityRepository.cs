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
(select top 1 {nameof(Facility.SiteCode)} from {nameof(MnchContext.Facilities)} where {nameof(Facility.Id)}='{facilityId}') FacilityCode,
(select ISNULL(max({nameof(PatientMnch.DateCreated)}),GETDATE()) from {nameof(MnchContext.MnchPatients)} where {nameof(PatientMnch.FacilityId)}='{facilityId}') Updated,
(select count(id) from {nameof(MnchContext.MnchPatients)} where facilityid='{facilityId}') {nameof(PatientMnch)},
(select count(id) from {nameof(MnchContext.MnchEnrolments)} where facilityid='{facilityId}') {nameof(MnchEnrolment)},
(select count(id) from {nameof(MnchContext.MnchArts)} where facilityid='{facilityId}') {nameof(MnchArt)},
(select count(id) from {nameof(MnchContext.AncVisits)} where facilityid='{facilityId}') {nameof(AncVisit)},
(select count(id) from {nameof(MnchContext.MatVisits)} where facilityid='{facilityId}') {nameof(MatVisit)},
(select count(id) from {nameof(MnchContext.PncVisits)} where facilityid='{facilityId}') {nameof(PncVisit)},
(select count(id) from {nameof(MnchContext.MotherBabyPairs)} where facilityid='{facilityId}') {nameof(MotherBabyPair)},
(select count(id) from {nameof(MnchContext.CwcEnrolments)} where facilityid='{facilityId}') {nameof(CwcEnrolment)},
(select count(id) from {nameof(MnchContext.CwcVisits)} where facilityid='{facilityId}') {nameof(CwcVisit)},
(select count(id) from {nameof(MnchContext.Heis)} where facilityid='{facilityId}') {nameof(Hei)},
(select count(id) from {nameof(MnchContext.MnchLabs)} where facilityid='{facilityId}') {nameof(MnchLab)}
";

            var result = GetDbConnection().Query<dynamic>(sql).FirstOrDefault();

            if (null != result)
            {
                var stats=new StatsDto(result.FacilityCode,result.Updated);
                stats.AddStats($"{nameof(PatientMnch)}",result.PatientMnch);
                stats.AddStats($"{nameof(MnchEnrolment)}",result.MnchEnrolment);
                stats.AddStats($"{nameof(MnchArt)}",result.MnchArt);
                stats.AddStats($"{nameof(AncVisit)}",result.AncVisit);
                stats.AddStats($"{nameof(MatVisit)}",result.MatVisit);
                stats.AddStats($"{nameof(PncVisit)}",result.PncVisit);
                stats.AddStats($"{nameof(MotherBabyPair)}",result.MotherBabyPair);
                stats.AddStats($"{nameof(CwcEnrolment)}",result.CwcEnrolment);
                stats.AddStats($"{nameof(CwcVisit)}",result.CwcVisit);
                stats.AddStats($"{nameof(Hei)}",result.Hei);
                stats.AddStats($"{nameof(MnchLab)}",result.MnchLab);
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
