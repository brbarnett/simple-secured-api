using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Legacy.Platform.Api.Services;
using MediatR;

namespace Legacy.Platform.Api.Requests.Values
{
    public class GetAllValuesQuery : IRequest<IEnumerable<string>>
    {
    }

    public class GetAllValuesQueryHandler : IRequestHandler<GetAllValuesQuery, IEnumerable<string>>
    {
        private readonly IValuesService _valuesService;

        public GetAllValuesQueryHandler(IValuesService valuesService)
        {
            this._valuesService = valuesService ?? throw new ArgumentNullException(nameof(valuesService));
        }

        public async Task<IEnumerable<string>> Handle(GetAllValuesQuery request, CancellationToken cancellationToken)
        {
            return this._valuesService.GetAllValues();
        }
    }
}