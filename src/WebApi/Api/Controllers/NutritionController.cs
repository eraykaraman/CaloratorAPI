using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Queries.GetNutritions;
using Application.Features.Queries.GetNutritionByName;
using Application.Features.Queries.GetNutritionById;
using Application.Features.Commands.User.Create;
using Application.Features.Commands.Nutrition.Create;
using Application.Features.Commands.Nutrition.Update;
using Application.Features.Commands.Nutrition.Delete;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NutritionController : BaseController
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNutritionCommandRequest request)
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
        public async Task<IActionResult> Update([FromBody] UpdateNutritionCommandRequest request)
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
        public async Task<IActionResult> Delete([FromBody] DeleteNutritionCommandRequest request)
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

    }
}
