using Application.Activities.Contracts;
using Application.Activities.Dtos;
using Application.Commons.Contracts;
using Domain.Activities;

namespace Application.Activities.Features.Commands;

public record CreateActivityRequest(
   string Title,
   DateTime Date,
   string Description,
   string Category,
   string City,
   string Venue,
   double Latitude,
   double Longitude
);

public record CreateActivityCommand(CreateActivityRequest Request) : IRequest<Result<ActivityKeyDto>>;

internal class CreateActivityCommandHandler(IActivityRepository activityRepository,IUnitOfWork unitOfWork) : IRequestHandler<CreateActivityCommand, Result<ActivityKeyDto>>
{

   public async Task<Result<ActivityKeyDto>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
   {
      var activity = Activity.Create(
          request.Request.Title,
          request.Request.Date,
          request.Request.Description,
          request.Request.Category,
          request.Request.City,
          request.Request.Venue,
          request.Request.Latitude,
          request.Request.Longitude
      );

      activityRepository.Add(activity);
      var result = await unitOfWork.CommitChangesAsync(cancellationToken);

      return Result.Ok(new ActivityKeyDto(activity.Id));
   }
}

