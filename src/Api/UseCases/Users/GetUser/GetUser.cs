using MediatR;
using Microsoft.Extensions.Logging;
using Strategio.Core.UseCases.Outputs;
using System.Threading;
using System.Threading.Tasks;

namespace Api.UseCases.Users.GetUser
{
    public class GetUser : IRequestHandler<GetUserInput, Output>
    {
        private readonly ILogger<GetUser> logger;

        public GetUser(
            ILogger<GetUser> logger)
        {
            this.logger = logger;
        }

        public async Task<Output> Handle(GetUserInput requestInput, CancellationToken cancellationToken)
        {
            var requestOutput = new Output();

            try
            {
                logger.LogInformation("starting GetUser");
                await HandleInternal(requestInput, requestOutput);
                logger.LogInformation("finishing GetUser");
                return requestOutput;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "error on GetUser");
                throw;
            }
        }

        private async Task HandleInternal(GetUserInput requestInput, Output requestOutput)
        {
            await Task.CompletedTask;
        }
    }
}
