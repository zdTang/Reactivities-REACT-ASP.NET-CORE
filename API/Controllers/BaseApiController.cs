using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

// understand how to assess Services via HttpContext
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();
    }
}