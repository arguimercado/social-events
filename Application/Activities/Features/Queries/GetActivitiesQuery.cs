using Application.Activities.Contracts;
using Application.Activities.Dtos;


namespace Application.Activities.Features.Queries;

public record GetActivitiesQuery() : IRequest<Result<IEnumerable<ActivityDto>>>;

internal class GetActivitiesQueryHandler(IActivityRepository activityRepository) : 
IRequestHandler<GetActivitiesQuery, Result<IEnumerable<ActivityDto>>>
{
   public async Task<Result<IEnumerable<ActivityDto>>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
   {
      var activities = await activityRepository.GetActivitiesAsync(cancellationToken);

      return Result.Ok<IEnumerable<ActivityDto>>(activities.Select(a => new ActivityDto(a)));
    }
}

