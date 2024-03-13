using Application.Features.Commands.Category.Create;
using Application.Features.Commands.Category.Delete;
using Application.Features.Commands.Category.Update;
using Application.Features.Commands.Nutrition.Create;
using Application.Features.Queries.GetCategories;
using Application.Features.Queries.GetCategoryById;
using Application.Features.Queries.GetCategoryNutritions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator=mediator;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            try
            {
                var nutrition = await mediator.Send(new GetCategoryByIdQueryRequest(id));
                return Ok(nutrition);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await mediator.Send(new GetCategoriesQueryRequest());
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kategoriler listelenirken bir sorun oluştu.");
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryNutritions(Guid categoryId)
        {
            try
            {
                var result = await mediator.Send(new GetCategoryNutritionsQueryRequest(categoryId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kategori nesneleri listelenirken bir sorun oluştu.");
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request)
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


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request)
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


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommandRequest request)
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
