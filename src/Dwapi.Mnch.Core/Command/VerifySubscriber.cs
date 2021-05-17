using Dwapi.Mnch.SharedKernel.Model;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class VerifySubscriber : IRequest<VerificationResponse>
    {
        public string DocketId { get; set; }
        public string SubscriberId { get; }
        public string AuthToken { get; }

        public VerifySubscriber(string subscriberId, string authToken,string docketId="MNCH")
        {
            DocketId = docketId;
            SubscriberId = subscriberId;
            AuthToken = authToken;
        }
    }
}
