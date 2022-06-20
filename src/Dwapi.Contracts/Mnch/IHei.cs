using System;

namespace Dwapi.Mnch.Contracts.Mnch
{
    public interface IHei
    {
        public string FacilityName { get; set; }
        public string PatientMnchID { get; set; }
        public DateTime? DNAPCR1Date { get; set; }
        public DateTime? DNAPCR2Date { get; set; }
        public DateTime? DNAPCR3Date { get; set; }
        public DateTime? ConfirmatoryPCRDate { get; set; }
        public DateTime? BasellineVLDate { get; set; }
        public DateTime? FinalyAntibodyDate { get; set; }
        public string? DNAPCR1 { get; set; }
        public string? DNAPCR2 { get; set; }
        public string? DNAPCR3 { get; set; }
        public string? ConfirmatoryPCR { get; set; }
        public string? BasellineVL { get; set; }
        public string? FinalyAntibody { get; set; }
        public DateTime? HEIExitDate { get; set; }
        public string? HEIHIVStatus { get; set; }
        public string? HEIExitCritearia { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
    }
}
