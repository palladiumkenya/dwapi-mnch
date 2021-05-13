using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class SnapMasterFacility:IRequest<bool>
    {
        public int SiteCode { get; }

        public SnapMasterFacility(int siteCode)
        {
            SiteCode = siteCode;
        }
    }

}
