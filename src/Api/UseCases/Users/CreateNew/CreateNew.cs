using MediatR;
using Microsoft.Extensions.Logging;
using Strategio.Core.UseCases.Outputs;
using System.Threading;
using System.Threading.Tasks;

namespace Api.UseCases.Users.CreateNew
{
    public class CreateNew : IRequestHandler<CreateNewInput, Output>
    {
        private readonly ILogger<CreateNew> logger;

        public CreateNew(
            ILogger<CreateNew> logger)
        {
            this.logger = logger;
        }

        public async Task<Output> Handle(CreateNewInput requestInput, CancellationToken cancellationToken)
        {
            var requestOutput = new Output();

            try
            {
                logger.LogInformation("starting CreateNew");
                await HandleInternal(requestInput, requestOutput);
                logger.LogInformation("finishing CreateNew");
                return requestOutput;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "error on CreateNew");
                throw;
            }
        }

        private async Task HandleInternal(CreateNewInput requestInput, Output requestOutput)
        {
            await Task.CompletedTask;
        }
    }
}
