using System;

namespace Dwapi.Mnch.SharedKernel.Model
{
    public interface IExtract
    {
        int PatientPk { get; set; }
        int SiteCode { get; set; }
        string Emr { get; set; }
        string Project { get; set; }
        bool? Processed { get; set; }
        string QueueId { get; set; }
        string Status { get; set; }
        DateTime? StatusDate { get; set; }
        DateTime? DateExtracted { get; set; }
        public Guid FacilityId { get; set; }
    }
}
