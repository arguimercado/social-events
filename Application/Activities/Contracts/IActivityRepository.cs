using Application.Commons.Contracts;
using Domain.Activities;

namespace Application.Activities.Contracts;

public interface IActivityRepository : IBaseRepository<Activity>
{
   Task<IEnumerable<Activity>> GetActivitiesAsync(CancellationToken cancellationToken = default);
}
