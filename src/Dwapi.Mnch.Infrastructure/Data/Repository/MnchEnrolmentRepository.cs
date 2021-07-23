using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;

namespace Dwapi.Mnch.Infrastructure.Data.Repository
{
    public class MnchEnrolmentRepository : BaseRepository<MnchEnrolment,Guid>, IMnchEnrolmentRepository{public MnchEnrolmentRepository(MnchContext context) : base(context){}public void Process(Guid facilityId,IEnumerable<MnchEnrolment> extracts){var mpi = extracts.ToList();if (mpi.Any()){mpi.ForEach(x => x.FacilityId = facilityId);CreateBulk(mpi);}}}
}