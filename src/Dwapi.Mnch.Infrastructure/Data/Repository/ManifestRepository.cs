using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Domain.Dto;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.SharedKernel.Enums;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Mnch.Infrastructure.Data.Repository
{
    public class ManifestRepository : BaseRepository<Manifest, Guid>, IManifestRepository
    {
        public ManifestRepository(MnchContext context) : base(context)
        {
        }

        public void ClearFacility(IEnumerable<Manifest> manifests)
        {
            var ids = string.Join(',', manifests.Select(x =>$"'{x.FacilityId}'"));
            ExecSql(
                $@"
                    DELETE FROM {nameof(MnchContext.MnchPatients)} WHERE {nameof(PatientMnch.FacilityId)} in ({ids}) AND {nameof(PatientMnch.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.MnchEnrolments)} WHERE {nameof(MnchEnrolment.FacilityId)} in ({ids}) AND {nameof(MnchEnrolment.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.MnchArts)} WHERE {nameof(MnchArt.FacilityId)} in ({ids}) AND {nameof(MnchArt.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.AncVisits)} WHERE {nameof(AncVisit.FacilityId)} in ({ids}) AND {nameof(AncVisit.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.MatVisits)} WHERE {nameof(MatVisit.FacilityId)} in ({ids}) AND {nameof(MatVisit.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.PncVisits)} WHERE {nameof(PncVisit.FacilityId)} in ({ids}) AND {nameof(PncVisit.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.MotherBabyPairs)} WHERE {nameof(MotherBabyPair.FacilityId)} in ({ids}) AND {nameof(MotherBabyPair.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.CwcEnrolments)} WHERE {nameof(CwcEnrolment.FacilityId)} in ({ids}) AND {nameof(CwcEnrolment.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.CwcVisits)} WHERE {nameof(CwcVisit.FacilityId)} in ({ids}) AND {nameof(CwcVisit.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.Heis)} WHERE {nameof(Hei.FacilityId)} in ({ids}) AND {nameof(Hei.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.MnchLabs)} WHERE {nameof(MnchLab.FacilityId)} in ({ids}) AND {nameof(MnchLab.Project)} <> 'IRDO';
                 "
                );

            var mids = string.Join(',', manifests.Select(x => $"'{x.Id}'"));
            ExecSql(
                $@"
                    UPDATE
                        {nameof(MnchContext.Manifests)}
                    SET
                        {nameof(Manifest.Status)}={(int)ManifestStatus.Processed},
                        {nameof(Manifest.StatusDate)}=GETDATE()
                    WHERE
                        {nameof(Manifest.Id)} in ({mids})");
        }

        public void ClearFacility(IEnumerable<Manifest> manifests, string project)
        {
            var ids = string.Join(',', manifests.Select(x =>$"'{x.FacilityId}'"));
            ExecSql(
                $@"
                    DELETE FROM {nameof(MnchContext.MnchPatients)} WHERE {nameof(PatientMnch.FacilityId)} in ({ids}) AND {nameof(PatientMnch.Project)}='{project}';                   
                    DELETE FROM {nameof(MnchContext.MnchEnrolments)} WHERE {nameof(MnchEnrolment.FacilityId)} in ({ids}) AND {nameof(MnchEnrolment.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MnchArts)} WHERE {nameof(MnchArt.FacilityId)} in ({ids}) AND {nameof(MnchArt.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.AncVisits)} WHERE {nameof(AncVisit.FacilityId)} in ({ids}) AND {nameof(AncVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MatVisits)} WHERE {nameof(MatVisit.FacilityId)} in ({ids}) AND {nameof(MatVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.PncVisits)} WHERE {nameof(PncVisit.FacilityId)} in ({ids}) AND {nameof(PncVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MotherBabyPairs)} WHERE {nameof(MotherBabyPair.FacilityId)} in ({ids}) AND {nameof(MotherBabyPair.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.CwcEnrolments)} WHERE {nameof(CwcEnrolment.FacilityId)} in ({ids}) AND {nameof(CwcEnrolment.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.CwcVisits)} WHERE {nameof(CwcVisit.FacilityId)} in ({ids}) AND {nameof(CwcVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.Heis)} WHERE {nameof(Hei.FacilityId)} in ({ids}) AND {nameof(Hei.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MnchLabs)} WHERE {nameof(MnchLab.FacilityId)} in ({ids}) AND {nameof(MnchLab.Project)}='{project}';
                 "
            );

            var mids = string.Join(',', manifests.Select(x => $"'{x.Id}'"));
            ExecSql(
                $@"
                    UPDATE
                        {nameof(MnchContext.Manifests)}
                    SET
                        {nameof(Manifest.Status)}={(int)ManifestStatus.Processed},
                        {nameof(Manifest.StatusDate)}=GETDATE()
                    WHERE
                        {nameof(Manifest.Id)} in ({mids})");
        }

        public int GetPatientCount(Guid id)
        {
            var ctt = Context as MnchContext;
            var cargo = ctt.Cargoes.FirstOrDefault(x => x.ManifestId == id && x.Type == CargoType.Patient);
            if (null != cargo)
                return cargo.Items.Split(",").Length;

            return 0;
        }

        public IEnumerable<Manifest> GetStaged(int siteCode)
        {
            var ctt = Context as MnchContext;
            var manifests = DbSet.AsNoTracking().Where(x => x.Status == ManifestStatus.Staged && x.SiteCode == siteCode)
                .ToList();

            foreach (var manifest in manifests)
            {
                manifest.Cargoes = ctt.Cargoes.AsNoTracking()
                    .Where(x => x.Type != CargoType.Patient && x.ManifestId == manifest.Id).ToList();
            }

            return manifests;
        }

        public async Task EndSession(Guid session)
        {
            var end = DateTime.Now;
            var sql = $"UPDATE {nameof(MnchContext.Manifests)} SET [{nameof(Manifest.End)}]=@end WHERE [{nameof(Manifest.Session)}]=@session";
            await Context.Database.GetDbConnection().ExecuteAsync(sql, new {session, end});
        }

        public IEnumerable<HandshakeDto> GetSessionHandshakes(Guid session)
        {
            var sql = $"SELECT * FROM {nameof(MnchContext.Manifests)} WHERE [{nameof(Manifest.Session)}]=@session";
            var manifests = Context.Database.GetDbConnection().Query<Manifest>(sql,new{session}).ToList();
            return manifests.Select(x => new HandshakeDto()
            {
                Id = x.Id, End = x.End, Session = x.Session, Start = x.Start
            });
        }
        public void updateCount(Guid id, int clientCount)
        {
            var sql =
                $"UPDATE {nameof(MnchContext.Manifests)} SET [{nameof(Manifest.Recieved)}]=@clientCount WHERE [{nameof(Manifest.Id)}]=@id";
            Context.Database.GetDbConnection().Execute(sql, new { id, clientCount });
        }
    }
}
