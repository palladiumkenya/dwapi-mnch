using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.ExtractsManagement.Core.Model.Destination.Mnch;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;

namespace Dwapi.Mnch.Infrastructure.Data.Repository
{
    public class MnchImmunizationRepository : BaseRepository<MnchImmunization,Guid>, IMnchImmunizationRepository{public MnchImmunizationRepository(MnchContext context) : base(context){}public void Process(Guid facilityId,IEnumerable<MnchImmunization> extracts){var mpi = extracts.ToList();if (mpi.Any()){mpi.ForEach(x => x.FacilityId = facilityId);CreateBulk(mpi);}}}
}