using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        private readonly IMediator mediator;

        public NutritionController(IMediator mediator)
        {
            this.mediator=mediator;
        }

        
    }
}
