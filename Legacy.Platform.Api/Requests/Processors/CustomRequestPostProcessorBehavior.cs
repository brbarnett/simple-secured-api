using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Legacy.Platform.Api.Requests.Configuration
{
    public class CustomRequestPostProcessorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IRequestPostProcessor<TRequest, TResponse>> _postProcessors;

        public CustomRequestPostProcessorBehavior(
            IEnumerable<IRequestPostProcessor<TRequest, TResponse>> postProcessors)
        {
            this._postProcessors = postProcessors ?? throw new ArgumentNullException(nameof(postProcessors));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                var response = await next().ConfigureAwait(false);

                foreach (var processor in this._postProcessors)
                {
                    await processor.Process(request, response).ConfigureAwait(false);
                }

                return response;
            }
            catch (Exception e)
            {
                // todo: log all exceptions

                throw;
            }
        }
    }
}