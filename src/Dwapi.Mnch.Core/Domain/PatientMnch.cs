using System;
using Dwapi.Mnch.Contracts.Mnch;
using Dwapi.Mnch.SharedKernel.Model;

namespace Dwapi.Mnch.Core.Domain
{
    public class PatientMnch : Entity<Guid>,IExtract,IPatientMnch
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
        public string Pkv { get; set; }
        public string PatientMnchID { get; set; }
        public string PatientHeiID { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? FirstEnrollmentAtMnch { get; set; }
        public string Occupation { get; set; }
        public string MaritalStatus { get; set; }
        public string EducationLevel { get; set; }
        public string PatientResidentCounty { get; set; }
        public string PatientResidentSubCounty { get; set; }
        public string PatientResidentWard { get; set; }
        public string InSchool { get; set; }
        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }
        public string NUPI { get; set; }
        public string RecordUUID { get; set; }
        public bool? Voided { get; set; }
        
        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }

    }
}
