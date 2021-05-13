using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveCwcEnrolment : IRequest<Guid>{public IEnumerable<CwcEnrolment> ClientCwcEnrolment { get; set; }public SaveCwcEnrolment( IEnumerable<CwcEnrolment> extracts){ClientCwcEnrolment = extracts;}}
}