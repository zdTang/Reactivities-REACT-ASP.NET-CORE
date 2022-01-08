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
            //if return null, then it is a 204, Which is not a Error
            // Find Activity by ID, edit an Activity by ID are all need search first
            // if nothing find , by default ,it will return a null
            // But we will make it even more clear, and send back a NotFound() 
            if (result == null) return NotFound();// vs result.Value==null

            if (result.IsSuccess && result.Value != null)
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null)
                return NotFound();
            return BadRequest();
        }
    }
}
