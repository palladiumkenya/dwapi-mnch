using System;
using System.Collections.Generic;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveMotherBabyPair : IRequest<Guid>{public IEnumerable<MotherBabyPair> ClientMotherBabyPair { get; set; }public SaveMotherBabyPair( IEnumerable<MotherBabyPair> extracts){ClientMotherBabyPair = extracts;}}
}