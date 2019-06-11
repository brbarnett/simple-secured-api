using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Legacy.Platform.Api.Services;
using MediatR;

namespace Legacy.Platform.Api.Requests.Values
{
    public class CreateValueCommand : IRequest
    {
        [Required]
        public string Value { get; set; }
    }

    public class CreateValueCommandHandler : IRequestHandler<CreateValueCommand, Unit>
    {
        private readonly IValuesService _valuesService;

        public CreateValueCommandHandler(IValuesService valuesService)
        {
            this._valuesService = valuesService ?? throw new ArgumentNullException(nameof(valuesService));
        }

        public async Task<Unit> Handle(CreateValueCommand request, CancellationToken cancellationToken)
        {
            this._valuesService.CreateValue(request.Value);

            return Unit.Value;
        }
    }
}