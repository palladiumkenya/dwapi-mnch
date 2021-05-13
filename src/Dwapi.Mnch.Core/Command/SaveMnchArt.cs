using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveMnchArt : IRequest<Guid>{public IEnumerable<MnchArt> ClientMnchArt { get; set; }public SaveMnchArt( IEnumerable<MnchArt> extracts){ClientMnchArt = extracts;}}
}