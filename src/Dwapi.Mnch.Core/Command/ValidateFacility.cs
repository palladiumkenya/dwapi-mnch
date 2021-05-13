using Dwapi.Mnch.Core.Domain;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class ValidateFacility: IRequest<MasterFacility>
    {
        public int SiteCode { get; }

        public ValidateFacility(int siteCode)
        {
            SiteCode = siteCode;
        }
    }
}