using Application.Activities.Contracts;
using Application.Activities.Dtos;



namespace Application.Activities.Features.Queries;

public record GetActivityByIdQuery(long Id) : IRequest<Result<ActivityDto>>;

internal class GetActivityByIdQueryHandler(IActivityRepository repository) : IRequestHandler<GetActivityByIdQuery, Result<ActivityDto>>
{
    public async Task<Result<ActivityDto>> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await repository.GetActivityByIdAsync(request.Id, cancellationToken);
        if (activity is null) {
            return Result.Fail(new NotFoundError($"Activity with ID {request.Id} not found."));  
        }

        return Result.Ok(new ActivityDto(activity));
    }
}
