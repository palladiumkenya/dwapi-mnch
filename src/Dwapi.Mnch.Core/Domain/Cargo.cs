using System;
using Dwapi.Mnch.SharedKernel.Enums;
using Dwapi.Mnch.SharedKernel.Model;

namespace Dwapi.Mnch.Core.Domain
{
    public class Cargo : Entity<Guid>
    {
        public CargoType Type { get; set; }
        public string Items { get; set; }
        public Guid ManifestId { get; set; }

        public Cargo()
        {
        }
    }
}