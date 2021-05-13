using System;
using MediatR;

namespace Dwapi.Mnch.Core.Command
{
    public class ValidateFacilityKey: IRequest<bool>
    {
        public Guid Key { get; }

        public ValidateFacilityKey(Guid key)
        {
            Key = key;
        }
    }
}