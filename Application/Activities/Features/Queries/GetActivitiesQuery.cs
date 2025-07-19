using Application.Activities.Contracts;
using Domain.Activities;


namespace Application.Activities.Features.Queries;

public record GetActivitiesQuery() : IRequest<Result<IEnumerable<Activity>>>;

internal class GetActivitiesQueryHandler(IActivityRepository activityRepository) : 
IRequestHandler<GetActivitiesQuery, Result<IEnumerable<Activity>>>
{
   public async Task<Result<IEnumerable<Activity>>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
   {
      

      var activities = await activityRepository.GetActivitiesAsync(cancellationToken);

      return Result.Ok<IEnumerable<Activity>>(activities);
    }
}

