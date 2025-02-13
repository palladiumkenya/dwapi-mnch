using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dwapi.ExtractsManagement.Core.Model.Destination.Mnch;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Domain.Dto;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.SharedKernel.Enums;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Serilog;

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
            var sitecode = manifests.Select(x =>$"'{x.SiteCode}'").FirstOrDefault();

            ExecSql(
                $@"
                    DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.MnchPatients)} WHERE {nameof(PatientMnch.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            
            try{
            ExecSql(
                $@"        
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.MnchEnrolments)} WHERE {nameof(MnchEnrolment.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.MnchEnrolments)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.MnchArts)} WHERE {nameof(MnchArt.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.MnchArts)}"+ e);

            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.AncVisits)} WHERE {nameof(AncVisit.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.AncVisits)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.PncVisits)} WHERE {nameof(PncVisit.SiteCode)} = {sitecode} ;
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.PncVisits)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.MatVisits)} WHERE {nameof(MatVisit.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.MatVisits)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.MotherBabyPairs)} WHERE {nameof(MotherBabyPair.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.MotherBabyPairs)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.CwcEnrolments)} WHERE {nameof(CwcEnrolment.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.CwcEnrolments)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.CwcVisits)} WHERE {nameof(CwcVisit.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.CwcVisits)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.Heis)} WHERE {nameof(Hei.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.Heis)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.MnchLabs)} WHERE {nameof(MnchLab.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600);
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.MnchLabs)}"+ e);
            }
            
            try{
            ExecSql(
                $@" 
                DECLARE @BatchSize INT = 50000; 
                    DECLARE @RowsAffected INT = 1;
                    WHILE @RowsAffected > 0
                    BEGIN
                        DELETE TOP (@BatchSize) {nameof(MnchContext.MnchImmunizations)} WHERE {nameof(MnchImmunization.SiteCode)} = {sitecode};
                        SET @RowsAffected = @@ROWCOUNT;
                    END
                ", 3600); 
            }
            catch (Exception e)
            {
                Log.Error( $"Clear ERROR {nameof(MnchContext.MnchImmunizations)}"+ e);
            }





//               ExecSql(
//                   $@"
//                       DELETE FROM {nameof(MnchContext.MnchPatients)} WHERE {nameof(PatientMnch.SiteCode)} = {sitecode} AND {nameof(PatientMnch.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.MnchEnrolments)} WHERE {nameof(MnchEnrolment.SiteCode)} = {sitecode} AND {nameof(MnchEnrolment.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.MnchArts)} WHERE {nameof(MnchArt.SiteCode)} = {sitecode} AND {nameof(MnchArt.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.AncVisits)} WHERE {nameof(AncVisit.SiteCode)} = {sitecode} AND {nameof(AncVisit.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.MatVisits)} WHERE {nameof(MatVisit.SiteCode)} = {sitecode} AND {nameof(MatVisit.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.PncVisits)} WHERE {nameof(PncVisit.SiteCode)} = {sitecode} AND {nameof(PncVisit.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.MotherBabyPairs)} WHERE {nameof(MotherBabyPair.SiteCode)} = {sitecode} AND {nameof(MotherBabyPair.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.CwcEnrolments)} WHERE {nameof(CwcEnrolment.SiteCode)} = {sitecode} AND {nameof(CwcEnrolment.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.CwcVisits)} WHERE {nameof(CwcVisit.SiteCode)} = {sitecode} AND {nameof(CwcVisit.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.Heis)} WHERE {nameof(Hei.SiteCode)} = {sitecode} AND {nameof(Hei.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.MnchLabs)} WHERE {nameof(MnchLab.SiteCode)} = {sitecode} AND {nameof(MnchLab.Project)} <> 'IRDO';
//                       DELETE FROM {nameof(MnchContext.MnchImmunizations)} WHERE {nameof(MnchImmunization.SiteCode)} = {sitecode} AND {nameof(MnchImmunization.Project)} <> 'IRDO';
//
//                    "
//                   );

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
            var sitecode = string.Join(',', manifests.Select(x =>$"'{x.SiteCode}'"));

            var ids = string.Join(',', manifests.Select(x =>$"'{x.FacilityId}'"));
            ExecSql(
                $@"
                    DELETE FROM {nameof(MnchContext.MnchPatients)} WHERE {nameof(PatientMnch.SiteCode)} = {sitecode} AND {nameof(PatientMnch.Project)}='{project}';                   
                    DELETE FROM {nameof(MnchContext.MnchEnrolments)} WHERE {nameof(MnchEnrolment.SiteCode)} = {sitecode} AND {nameof(MnchEnrolment.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MnchArts)} WHERE {nameof(MnchArt.SiteCode)} = {sitecode} AND {nameof(MnchArt.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.AncVisits)} WHERE {nameof(AncVisit.SiteCode)} = {sitecode} AND {nameof(AncVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MatVisits)} WHERE {nameof(MatVisit.SiteCode)} = {sitecode} AND {nameof(MatVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.PncVisits)} WHERE {nameof(PncVisit.SiteCode)} = {sitecode} AND {nameof(PncVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MotherBabyPairs)} WHERE {nameof(MotherBabyPair.SiteCode)} = {sitecode} AND {nameof(MotherBabyPair.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.CwcEnrolments)} WHERE {nameof(CwcEnrolment.SiteCode)} = {sitecode} AND {nameof(CwcEnrolment.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.CwcVisits)} WHERE {nameof(CwcVisit.SiteCode)} = {sitecode} AND {nameof(CwcVisit.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.Heis)} WHERE {nameof(Hei.SiteCode)} = {sitecode} AND {nameof(Hei.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MnchLabs)} WHERE {nameof(MnchLab.SiteCode)} = {sitecode} AND {nameof(MnchLab.Project)}='{project}';
                    DELETE FROM {nameof(MnchContext.MnchImmunizations)} WHERE {nameof(MnchImmunization.SiteCode)} = {sitecode} AND {nameof(MnchImmunization.Project)}='{project}';

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
        
        public string GetDWAPIversionSending(int siteCode)
        {
            var ctt = Context as MnchContext;
            var manifests = DbSet.AsNoTracking().Where(x => x.Status == ManifestStatus.Staged && x.SiteCode == siteCode)
                .ToList();
            // DbSet.AsNoTracking().FacMetrics.Select(o => o.Metric).Where(x => x.Contains("CareTreatment")).ToList()[0]
        
            foreach (var manifest in manifests)
            {
                manifest.Cargoes = ctt.Cargoes.AsNoTracking()
                    .Where(x => x.Type != CargoType.Patient && x.ManifestId == manifest.Id).ToList();
            }
            var version = manifests.Select(o => o.Cargoes).Select(x =>  x.Where(m => m.Items.Contains("HivTestingService"))).FirstOrDefault().ToList()[0].Items;
            
            return JObject.Parse(version)["Version"].ToString();
        }
        
    }
}
