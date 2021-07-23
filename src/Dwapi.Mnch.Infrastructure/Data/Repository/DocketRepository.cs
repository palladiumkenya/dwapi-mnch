using System.Threading.Tasks;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.SharedKernel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Mnch.Infrastructure.Data.Repository
{
    public class DocketRepository : BaseRepository<Docket, string>, IDocketRepository
    {
        public DocketRepository(MnchContext context) : base(context)
        {
        }
        public Task<Docket> FindAsync(string docket)
        {
           var ctx=Context as MnchContext;
            return ctx.Dockets.Include(x => x.Subscribers).AsTracking().FirstOrDefaultAsync(x => x.Id == docket);
        }
    }
}
