using Application.Activities.Contracts;
using Domain.Activities;
using Domain.Commons.Errors;

namespace Application.Activities.Features.Queries;

public record GetActivityByIdQuery(long Id) : IRequest<Result<Activity>>;

internal class GetActivityByIdQueryHandler(IActivityRepository repository) : IRequestHandler<GetActivityByIdQuery, Result<Activity>>
{
    public async Task<Result<Activity>> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await repository.GetActivityByIdAsync(request.Id, cancellationToken);
        if (activity is null) {
            return Result.Fail(new NotFoundError($"Activity with ID {request.Id} not found."));  
        }

        return Result.Ok(activity);
    }
}
