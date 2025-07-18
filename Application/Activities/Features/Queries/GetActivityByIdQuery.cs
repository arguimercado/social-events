using System;
using Application.Activities.Contracts;
using Domain.Activities;
using MediatR;

namespace Application.Activities.Features.Queries;

public record GetActivityByIdQuery(string Id) : IRequest<Activity>;

internal class GetActivityByIdQueryHandler(IActivityRepository repository) : IRequestHandler<GetActivityByIdQuery, Activity>
{
    public async Task<Activity> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await repository.GetActivityByIdAsync(request.Id, cancellationToken);
        if (activity is null) {
            throw new KeyNotFoundException($"Activity with ID {request.Id} not found.");
        }
        
        return activity;
    }
}
