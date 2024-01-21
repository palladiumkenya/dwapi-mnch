using System;
using Dwapi.Mnch.Contracts.Mnch;
using Dwapi.Mnch.SharedKernel.Model;

namespace Dwapi.Mnch.Core.Domain
{
    public class MnchEnrolment : Entity<Guid>,IExtract,IMnchEnrolment
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
        public string PatientMnchID { get; set; }
        public string FacilityName { get; set; }
        public string ServiceType { get; set; }
        public DateTime? EnrollmentDateAtMnch { get; set; }
        public DateTime? MnchNumber { get; set; }
        public DateTime? FirstVisitAnc { get; set; }
        public string Parity { get; set; }
        public int Gravidae { get; set; }
        public DateTime? LMP { get; set; }
        public DateTime? EDDFromLMP { get; set; }
        public string HIVStatusBeforeANC { get; set; }
        public DateTime? HIVTestDate { get; set; }
        public string PartnerHIVStatus { get; set; }
        public DateTime? PartnerHIVTestDate { get; set; }
        public string BloodGroup { get; set; }
        public string StatusAtMnch { get; set; }
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