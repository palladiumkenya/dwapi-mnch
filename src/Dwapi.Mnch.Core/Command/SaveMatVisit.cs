using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveMatVisit : IRequest<Guid>{public IEnumerable<MatVisit> ClientMatVisit { get; set; }public SaveMatVisit( IEnumerable<MatVisit> extracts){ClientMatVisit = extracts;}}
}