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
                    DELETE FROM {nameof(MnchContext.Clients)} WHERE {nameof(PatientMnch.FacilityId)} in ({ids}) AND {nameof(PatientMnch.Project)} <> 'IRDO';
                    DELETE FROM {nameof(MnchContext.ClientLinkages)} WHERE {nameof(AncVisit.FacilityId)} in ({ids}) AND {nameof(AncVisit.Project)} <> 'IRDO';
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
                    DELETE FROM {nameof(MnchContext.Clients)} WHERE {nameof(PatientMnch.FacilityId)} in ({ids}) AND {nameof(PatientMnch.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.ClientLinkages)} WHERE {nameof(AncVisit.FacilityId)} in ({ids}) AND {nameof(AncVisit.Project)}='{project}';
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
    }
}
