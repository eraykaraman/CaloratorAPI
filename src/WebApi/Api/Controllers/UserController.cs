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
        public async Task<IActionResult> Get(Guid id)
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

        [HttpGet("Username/{userName}")]
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

    }
}
