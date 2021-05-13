using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SavePncVisit : IRequest<Guid>{public IEnumerable<PncVisit> ClientPncVisit { get; set; }public SavePncVisit( IEnumerable<PncVisit> extracts){ClientPncVisit = extracts;}}
}