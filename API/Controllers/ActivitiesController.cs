using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
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
            return await Mediator.Send(new ListActivity.Query(),ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
             var result =await Mediator.Send(new Details.Query { Id = id });
             // when return a NULL, It will be a 204 Response, which means successful
             // if We want sent the Client a different Info, we can customize the respond
             if(result ==null) 
             {
                 return NotFound();
             };
             return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            Console.WriteLine(activity);
            Console.WriteLine(ModelState);
            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            // activity is from Request's body, and id is not abvious come with it
            // so that we need combine them together here.
            // 4-8 Adding an Edit Handler
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
