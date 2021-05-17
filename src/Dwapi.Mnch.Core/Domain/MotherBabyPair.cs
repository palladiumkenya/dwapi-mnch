using System;
using Dwapi.Mnch.Contracts.Mnch;
using Dwapi.Mnch.SharedKernel.Model;

namespace Dwapi.Mnch.Core.Domain
{
    public class MotherBabyPair : Entity<Guid>,IExtract,IMotherBabyPair
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
        public int BabyPatientPK { get; set; }
        public int MotherPatientPK { get; set; }
        public string BabyPatientMncHeiID { get; set; }
        public string MotherPatientMncHeiID { get; set; }
        public string PatientIDCCC { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }
    }
}