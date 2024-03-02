using Application.Features.Commands.User.ChangePassword;
using Application.Features.Commands.User.Create;
using Application.Features.Commands.User.Login;
using Application.Features.Commands.User.Update;
using Application.Features.Queries.GetUserDetail;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await mediator.Send(new GetUserDetailQueryRequest(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            try
            {
                var result = await mediator.Send(new GetUserDetailQueryRequest(Guid.Empty, userName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            try
            {
                var res = await mediator.Send(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest request)
        {
            try
            {
                var guid = await mediator.Send(request);
                return Ok(guid);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommandRequest command)
        {
            try
            {
                if (!command.UserId.HasValue)
                    command.UserId = UserId;
                var guid = await mediator.Send(command);

                return Ok(guid);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest command)
        {
            try
            {
                var guid = await mediator.Send(command);
                return Ok(guid);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
