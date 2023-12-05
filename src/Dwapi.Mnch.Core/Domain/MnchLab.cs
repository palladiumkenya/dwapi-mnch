using System;
using Dwapi.Mnch.Contracts.Mnch;
using Dwapi.Mnch.SharedKernel.Model;

namespace Dwapi.Mnch.Core.Domain
{
    public class MnchLab : Entity<Guid>,IExtract,IMnchLab
    {
        public int PatientPk { get; set; }
        public int SiteCode { get; set; }
        public string Emr { get; set; }
        public string Project { get; set; }
        public bool? Processed { get; set; }
        public string QueueId { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? DateExtracted { get; set; }
        public Guid FacilityId { get; set; }
        public string PatientMNCH_ID { get; set; }
        public string FacilityName { get; set; }
        public string SatelliteName { get; set; }
        public int? VisitID { get; set; }
        public DateTime? OrderedbyDate { get; set; }
        public DateTime? ReportedbyDate { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; }
        public string LabReason { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
        public string RecordUUID { get; set; }
        public bool? Voided { get; set; }
        
        
        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}