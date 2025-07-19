using Application.Activities.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
  

   [HttpGet]
   public async Task<IActionResult> GetActivities(CancellationToken cancellationToken)
   {
      var query = new GetActivitiesQuery();
      var activities = await Mediator.Send(query, cancellationToken);
      return HandleResult(activities);
   }

   [HttpGet("{id:long}")]
   public async Task<IActionResult> GetActivityById(long id, CancellationToken cancellationToken)
   {
      var query = new GetActivityByIdQuery(id);
      var activity = await Mediator.Send(query, cancellationToken);

      return HandleResult(activity);
   }
}
