using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Domain.Dto;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IManifestRepository : IRepository<Manifest, Guid>
    {
        void ClearFacility(IEnumerable<Manifest> manifests);
        void ClearFacility(IEnumerable<Manifest> manifests,string project);
        int GetPatientCount(Guid id);
        IEnumerable<Manifest> GetStaged(int siteCode);
        Task EndSession(Guid session);
        IEnumerable<HandshakeDto> GetSessionHandshakes(Guid session);
        void updateCount(Guid id,int clientCount);
        string GetDWAPIversionSending(int siteCode);

    }
}
