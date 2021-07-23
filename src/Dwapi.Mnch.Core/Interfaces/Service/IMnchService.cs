using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;

namespace Dwapi.Mnch.Core.Interfaces.Service
{
    public interface IMnchService
    {
        void Process(IEnumerable<PatientMnch> patients);
        void Process(IEnumerable<AncVisit> extracts);
        void Process(IEnumerable<MnchEnrolment> extracts);
        void Process(IEnumerable<MnchArt> extracts);
        void Process(IEnumerable<MatVisit> extracts);
        void Process(IEnumerable<PncVisit> extracts);
        void Process(IEnumerable<MotherBabyPair> extracts);
        void Process(IEnumerable<CwcEnrolment> extracts);
        void Process(IEnumerable<CwcVisit> extracts);
        void Process(IEnumerable<Hei> extracts);
        void Process(IEnumerable<MnchLab> extracts);
    }
}
