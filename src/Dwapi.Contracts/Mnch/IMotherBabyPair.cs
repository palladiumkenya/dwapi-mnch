using System;

namespace Dwapi.Mnch.Contracts.Mnch
{
    public interface IMotherBabyPair
    {
        int BabyPatientPK { get; set; }
        int MotherPatientPK { get; set; }
        string BabyPatientMncHeiID { get; set; }
        string MotherPatientMncHeiID { get; set; }
        string PatientIDCCC { get; set; }
        DateTime? Date_Created { get; set; }
        DateTime? Date_Last_Modified { get; set; }
        string RecordUUID { get; set; }
        bool? Voided { get; set; }
    }
}
