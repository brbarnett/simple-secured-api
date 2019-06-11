using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace VZE.EdgeTrainer.Api.Requests.Configuration
{
    public class LoggingRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        public LoggingRequestPreProcessor()
        {
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // todo: log request details. be careful not to include sensitive information (e.g., passwords)
            }
            catch { }

            return Task.CompletedTask;
        }
    }
}