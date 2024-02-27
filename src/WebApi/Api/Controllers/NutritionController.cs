using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Queries.GetNutritions;
using Application.Features.Queries.GetNutritionByName;
using Application.Features.Queries.GetNutritionById;

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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetNutritionById(Guid id)
        {
            try
            {
                var nutrition = await mediator.Send(new GetNutritionByIdQueryRequest(id));
                return Ok(nutrition);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Besin listelenirken bir sorun oluştu.");
            }
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Besinler listelenirken bir sorun oluştu.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] GetNutritionsByNameQueryRequest request)
        {
            try
            {
                var result = await mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Besinler listelenirken bir sorun oluştu.");
            }
        }



    }
}
