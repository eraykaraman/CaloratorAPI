using Application.Features.Commands.User.Create;
using Application.Features.Commands.User.Login;
using Application.Features.Queries.GetUserDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
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
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Kullanıcı getirilirken bir sorun oluştu.");

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
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Kullanıcı getirilirken bir sorun oluştu.");
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
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Giriş yapılırken bir sorun oluştu.");
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
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Kayıt yapılırken bir sorun oluştu. Lütfen tekrar deneyiniz.");
            }
        }

    }
}
