using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveHei : IRequest<Guid>{public IEnumerable<Hei> ClientHei { get; set; }public SaveHei( IEnumerable<Hei> extracts){ClientHei = extracts;}}
}