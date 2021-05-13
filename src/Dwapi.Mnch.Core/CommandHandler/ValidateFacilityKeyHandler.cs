using System.Threading;
using System.Threading.Tasks;
using Dwapi.Mnch.Core.Command;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.SharedKernel.Exceptions;
using MediatR;

namespace Dwapi.Mnch.Core.CommandHandler
{
    public class ValidateFacilityKeyHandler: IRequestHandler<ValidateFacilityKey,bool>
    {
        private readonly IFacilityRepository _repository;

        public ValidateFacilityKeyHandler(IFacilityRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ValidateFacilityKey request, CancellationToken cancellationToken)
        {
            var masterFacility =await _repository.GetAsync(x=>x.Id==request.Key);

            if (null==masterFacility)
                throw new FacilityNotFoundException(request.Key);

            return true;
        }
    }
}