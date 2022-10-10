using Api.Controllers.v1.Users.Transport.CreateNew;
using Api.Controllers.v1.Users.Transport.GetUser;
using Api.Controllers.v1.Users.Transport.GetUsers;
using Api.UseCases.Users.CreateNew;
using Api.UseCases.Users.GetUser;
using Api.UseCases.Users.GetUsers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using System;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Users
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(
            [FromRoute] Guid userId,)
        {
            using var cid = LogContext.PushProperty("ProcessId", Guid.NewGuid());
            using var c1 = LogContext.PushProperty("RequestParameters.userId", userId);

            var input = new GetUserInput() { };

            var output = await _mediator.Send(input);
            if (output.IsValid)
            {
                var response = _mapper.Map<GetUserResponse>(output.GetResult());
                return Ok(response); 
            }

            return BadRequest(output.ErrorMessages);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUsersResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers(
            [FromQuery] GetUsersRequest request,)
        {
            using var c1 = LogContext.PushProperty("Execution.ExecutionId", Guid.NewGuid());
            using var c2 = LogContext.PushProperty("Execution.Parameters.request", JsonConvert.SerializeObject(request));

            var input = _mapper.Map<GetUsersInput>(request);

            var output = await _mediator.Send(input);
            if (output.IsValid)
            {
                var response = _mapper.Map<GetUsersResponse>(output.GetResult());
                return Ok(response); 
            }

            return BadRequest(output.ErrorMessages);
        } 

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNew(
            [FromBody] CreateNewRequest request,)
        {
            using var c1 = LogContext.PushProperty("Execution.ExecutionId", Guid.NewGuid());
            using var c2 = LogContext.PushProperty("Execution.Parameters.Request", JsonConvert.SerializeObject(request));

            var input = _mapper.Map<CreateNewInput>(request);

            var output = await _mediator.Send(input);
            if (output.IsValid)
            {
                return Ok(); 
            }

            return BadRequest(output.ErrorMessages);
        } 
    }
}
