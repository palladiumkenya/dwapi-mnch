using System;

namespace Dwapi.Mnch.Contracts.Mnch
{
    public interface IMnchLab
    {
        string PatientMNCH_ID { get; set; }
        string FacilityName { get; set; }
        string SatelliteName { get; set; }
        int? VisitID { get; set; }
        DateTime? OrderedbyDate { get; set; }
        DateTime? ReportedbyDate { get; set; }
        string TestName { get; set; }
        string TestResult { get; set; }
        string LabReason { get; set; }
        DateTime? Date_Created { get; set; }
        DateTime? Date_Last_Modified { get; set; }
        string RecordUUID { get; set; }
        bool? Voided { get; set; }
    }
}
