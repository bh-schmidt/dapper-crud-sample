using MediatR;
using Microsoft.Extensions.Logging;
using Strategio.Core.UseCases.Outputs;
using System.Threading;
using System.Threading.Tasks;

namespace Api.UseCases.Users.GetUsers
{
    public class GetUsers : IRequestHandler<GetUsersInput, Output>
    {
        private readonly ILogger<GetUsers> logger;

        public GetUsers(
            ILogger<GetUsers> logger)
        {
            this.logger = logger;
        }

        public async Task<Output> Handle(GetUsersInput requestInput, CancellationToken cancellationToken)
        {
            var requestOutput = new Output();

            try
            {
                logger.LogInformation("starting GetUsers");
                await HandleInternal(requestInput, requestOutput);
                logger.LogInformation("finishing GetUsers");
                return requestOutput;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "error on GetUsers");
                throw;
            }
        }

        private async Task HandleInternal(GetUsersInput requestInput, Output requestOutput)
        {
            await Task.CompletedTask;
        }
    }
}
