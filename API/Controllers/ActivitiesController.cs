using Microsoft.AspNetCore.Mvc;
using Domain;
//using MediatR;
using Application.Activities;
using System.Threading;


namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        /*    private readonly IMediator _mediator; 
            public ActivitiesController(IMediator mediator)
            {
                _mediator = mediator;
            }*/

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivies()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {

            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));

        }

        [HttpPut("{id}")] //for updating resources

        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {

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