using Application.Activities;
using Application.Core;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            var result = await Mediator.Send(new ListActivity.Query(), ct);
            return HandleResult(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Result<Activity>>> GetActivity(Guid id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            // when return a NULL, It will be a 204 Response, which means successful
            // if We want sent the Client a different Info, we can customize the respond
            // Here has a question.  who will tell it is Success or FAIL ?
            return HandleResult(result);

        }
        
     
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            var result = await Mediator.Send(new Create.Command { Activity = activity });
            return HandleResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            // activity is from Request's body, and id is not abvious come with it
            // so that we need combine them together here.
            // 4-8 Adding an Edit Handler
            activity.Id = id;
            var result = await Mediator.Send(new Edit.Command { Activity = activity });
            return HandleResult(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            var result = await Mediator.Send(new Delete.Command { Id = id });
            return HandleResult(result);
        }
    }
}
