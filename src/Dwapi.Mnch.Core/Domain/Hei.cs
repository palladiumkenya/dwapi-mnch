using System;
using Dwapi.Mnch.Contracts.Mnch;
using Dwapi.Mnch.SharedKernel.Model;

namespace Dwapi.Mnch.Core.Domain
{
    public class Hei : Entity<Guid>,IExtract,IHei
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
        public string FacilityName { get; set; }
        public string PatientMnchID { get; set; }
        public DateTime? DNAPCR1Date { get; set; }
        public DateTime? DNAPCR2Date { get; set; }
        public DateTime? DNAPCR3Date { get; set; }
        public DateTime? ConfirmatoryPCRDate { get; set; }
        public DateTime? BasellineVLDate { get; set; }
        public DateTime? FinalyAntibodyDate { get; set; }
        public string DNAPCR1 { get; set; }
        public string DNAPCR2 { get; set; }
        public string DNAPCR3 { get; set; }
        public string ConfirmatoryPCR { get; set; }
        public string BasellineVL { get; set; }
        public string FinalyAntibody { get; set; }
        public DateTime? HEIExitDate { get; set; }
        public string HEIHIVStatus { get; set; }
        public string HEIExitCritearia { get; set; }
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
