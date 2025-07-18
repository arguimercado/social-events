using Application.Activities.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
   public ActivitiesController(IMediator mediator) : base(mediator)
   {

   }

   [HttpGet]
   public async Task<IActionResult> GetActivities(CancellationToken cancellationToken)
   {
      var query = new GetActivitiesQuery();
      var activities = await Mediator.Send(query, cancellationToken);
      return Ok(activities);
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> GetActivityById(string id, CancellationToken cancellationToken)
   {
      var query = new GetActivityByIdQuery(id);
      var activity = await Mediator.Send(query, cancellationToken);
      return Ok(activity);
   }
}
