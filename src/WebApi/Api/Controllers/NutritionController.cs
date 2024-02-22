using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Queries.GetNutritions;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        private readonly IMediator mediator;

        public NutritionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetNutritions()
        {
            try
            {
                var nutritions = await mediator.Send(new GetNutritionsQueryRequest());
                return Ok(nutritions);
            }
            catch (Exception ex)
            {
                // Burada hata yakalama ve uygun bir HTTP yanıtı döndürme işlemleri yapılabilir
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
