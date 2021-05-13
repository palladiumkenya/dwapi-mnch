using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SavePatientMnch : IRequest<Guid>
    {
        public IEnumerable<PatientMnch> ClientPatientMnch { get; set; }

        public SavePatientMnch(IEnumerable<PatientMnch> extracts)
        {
            ClientPatientMnch = extracts;
        }
    }
}
