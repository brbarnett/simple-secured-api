using System;
using System.Threading;
using System.Threading.Tasks;
using Legacy.Platform.Api.Services;
using MediatR;

namespace Legacy.Platform.Api.Requests.Values
{
    public class GetValueByIndexQuery : IRequest<string>
    {
        public GetValueByIndexQuery(int index)
        {
            this.Index = index;
        }
        
        public int Index { get; set; }
    }

    public class GetValueByIndexQueryHandler : IRequestHandler<GetValueByIndexQuery, string>
    {
        private readonly IValuesService _valuesService;

        public GetValueByIndexQueryHandler(IValuesService valuesService)
        {
            this._valuesService = valuesService ?? throw new ArgumentNullException(nameof(valuesService));
        }

        public async Task<string> Handle(GetValueByIndexQuery request, CancellationToken cancellationToken)
        {
            return this._valuesService.GetValueByIndex(request.Index);
        }
    }
}