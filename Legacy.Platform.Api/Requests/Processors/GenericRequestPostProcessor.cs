using MediatR.Pipeline;
using System.Threading.Tasks;

namespace Legacy.Platform.Api.Requests.Configuration
{
    public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public Task Process(TRequest request, TResponse response)
        {
            return Task.CompletedTask;
        }
    }
}