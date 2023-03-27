using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dwapi.ExtractsManagement.Core.Model.Destination.Mnch;
using Dwapi.Mnch.SharedKernel.Model;
using Dwapi.Mnch.SharedKernel.Utils;

namespace Dwapi.Mnch.Core.Domain
{
    public class Facility : Entity<Guid>
    {
        public int SiteCode { get; set; }
        [MaxLength(120)] public string Name { get; set; }
        public int? MasterFacilityId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Emr { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public int? SnapshotSiteCode { get; set; }
        public int? SnapshotVersion { get; set; }

        public ICollection<PatientMnch> MnchPatients { get; set; }=new List<PatientMnch>();
        public virtual ICollection<MnchEnrolment> MnchEnrolments { get; set; } = new List<MnchEnrolment>();
        public ICollection<AncVisit> AncVisits { get; set; }=new List<AncVisit>();
        public virtual ICollection<MnchArt> MnchArts { get; set; } = new List<MnchArt>();
        public virtual ICollection<MatVisit> MatVisits { get; set; } = new List<MatVisit>();
        public virtual ICollection<PncVisit> PncVisits { get; set; } = new List<PncVisit>();
        public virtual ICollection<MotherBabyPair> MotherBabyPairs { get; set; } = new List<MotherBabyPair>();
        public virtual ICollection<CwcEnrolment> CwcEnrolments { get; set; } = new List<CwcEnrolment>();
        public virtual ICollection<CwcVisit> CwcVisits { get; set; } = new List<CwcVisit>();
        public virtual ICollection<Hei> Heis { get; set; } = new List<Hei>();
        public virtual ICollection<MnchLab> MnchLabs { get; set; } = new List<MnchLab>();
        public virtual ICollection<MnchImmunization> MnchImmunizations { get; set; } = new List<MnchImmunization>();

        public ICollection<Manifest> Manifests { get; set; }=new List<Manifest>();

        public Facility()
        {
        }

        public Facility(int siteCode, string name)
        {
            SiteCode = siteCode;
            Name = name;
        }

        public Facility(int siteCode, string name, int? masterFacilityId):this(siteCode,name)
        {
            MasterFacilityId = masterFacilityId;
        }

        public bool EmrChanged(string requestEmr)
        {
            if (string.IsNullOrWhiteSpace(requestEmr))
                return false;

            if (string.IsNullOrWhiteSpace(Emr))
                return false;

            if (requestEmr.IsSameAs("CHAK"))
                requestEmr = "IQCare";

            if (requestEmr.IsSameAs("IQCare") || requestEmr.IsSameAs("KenyaEMR"))
                return !Emr.IsSameAs(requestEmr);

            return false;
        }

        public Facility TakeSnapFrom(MasterFacility snapMfl)
        {
            var fac = this;

            fac.SnapshotDate = DateTime.Now;
            fac.SiteCode = snapMfl.Id;
            fac.SnapshotSiteCode = snapMfl.SnapshotSiteCode;
            fac.SnapshotVersion = snapMfl.SnapshotVersion;

            return fac;
        }

        public override string ToString()
        {
            return $"{Name} - {SiteCode}";
        }
    }
}
