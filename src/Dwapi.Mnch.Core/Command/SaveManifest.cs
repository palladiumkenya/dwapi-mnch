using System;
using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SaveManifest : IRequest<Guid>
    {
        public Manifest Manifest { get; set; }
        public bool AllowSnapshot { get; set; }
        public SaveManifest()
        {
        }

        public SaveManifest(Manifest manifest)
        {
            Manifest = manifest;
        }
    }
}
