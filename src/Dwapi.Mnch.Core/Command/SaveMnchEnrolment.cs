using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveMnchEnrolment : IRequest<Guid>{public IEnumerable<MnchEnrolment> ClientMnchEnrolment { get; set; }public SaveMnchEnrolment( IEnumerable<MnchEnrolment> extracts){ClientMnchEnrolment = extracts;}}
}