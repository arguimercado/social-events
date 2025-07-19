using Application.Activities.Contracts;
using Application.Commons.Contracts;

namespace Application.Activities.Features.Commands;

public record UpdateActivityRequest(
   string Title,
   DateTime Date,
   string Description,
   string Category,
   string City,
   string Venue,
   double Latitude,
   double Longitude
);
public record UpdateActivityCommand(long Id, UpdateActivityRequest Request) : IRequest<Result<Unit>>;

internal class UpdateActivityCommandHandler(IActivityRepository activityRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateActivityCommand, Result<Unit>>
{
   public async Task<Result<Unit>> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
   {
      var activity = await activityRepository.GetActivityByIdAsync(request.Id,true, cancellationToken);
      if (activity == null) {
         return Result.Fail<Unit>("Activity not found");
      }

      activity.Update(
         request.Request.Title,
         request.Request.Date,
         request.Request.Description,
         request.Request.Category,
         request.Request.City,
         request.Request.Venue,
         request.Request.Latitude,
         request.Request.Longitude
      );

      await unitOfWork.CommitChangesAsync(cancellationToken);
      return Result.Ok(Unit.Value);
   }
}
