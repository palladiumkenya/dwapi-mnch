using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveCwcVisit : IRequest<Guid>{public IEnumerable<CwcVisit> ClientCwcVisit { get; set; }public SaveCwcVisit( IEnumerable<CwcVisit> extracts){ClientCwcVisit = extracts;}}
}