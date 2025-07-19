using Application.Activities.Features.Commands;
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

   [HttpPost("")]
   public async Task<IActionResult> CreateActivity(CreateActivityRequest request, CancellationToken cancellationToken)
   {
      var command = new CreateActivityCommand(request);
      var result = await Mediator.Send(command, cancellationToken);

      return HandleResult(result);
   }

   [HttpPut("{id:long}")]
   public async Task<IActionResult> UpdateActivity(long id, UpdateActivityRequest request, CancellationToken cancellationToken)
   {
      var command = new UpdateActivityCommand(id, request);
      var result = await Mediator.Send(command, cancellationToken);

      return HandleResult(result);
   }
}
