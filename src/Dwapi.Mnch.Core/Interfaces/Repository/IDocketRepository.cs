using System.Threading.Tasks;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.SharedKernel.Interfaces;

namespace Dwapi.Mnch.Core.Interfaces.Repository
{
    public interface IDocketRepository : IRepository<Docket, string>
    {
       Task<Docket> FindAsync(string docket);
    }
}