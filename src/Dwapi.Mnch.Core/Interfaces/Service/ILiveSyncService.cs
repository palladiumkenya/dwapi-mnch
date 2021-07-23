using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Domain.Dto;

namespace Dwapi.Mnch.Core.Interfaces.Service
{
    public interface ILiveSyncService
    {
        void SyncManifest(Manifest manifest,int clientCount);
        void SyncStats(List<Guid> facilityId);
       void SyncMetrics(List<MetricDto> metrics);
       Task SyncHandshake(List<HandshakeDto> handshakeDtos);
    }
}
