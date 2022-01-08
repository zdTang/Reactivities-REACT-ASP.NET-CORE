using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // understand how to assess Services via HttpContext
        // Here, we cannot use DI in the constructor. so that we can use this approach
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();
            
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess && result.Value != null)
                //{ return NotFound(); }
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null)
                return NotFound();
            return BadRequest();
        }
    }
}
