using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveAncVisit : IRequest<Guid>{public IEnumerable<AncVisit> ClientAncVisit { get; set; }public SaveAncVisit( IEnumerable<AncVisit> extracts){ClientAncVisit = extracts;}}
}