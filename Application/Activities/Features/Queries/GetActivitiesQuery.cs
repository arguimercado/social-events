using Application.Activities.Contracts;
using Domain.Activities;
using MediatR;

namespace Application.Activities.Features.Queries;

public record GetActivitiesQuery() : IRequest<List<Activity>>;

internal class GetActivitiesQueryHandler(IActivityRepository activityRepository) : IRequestHandler<GetActivitiesQuery, List<Activity>>
{
   public async Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
   {
      var activities = await activityRepository.GetActivitiesAsync(cancellationToken);

      return [.. activities];
    }
}

