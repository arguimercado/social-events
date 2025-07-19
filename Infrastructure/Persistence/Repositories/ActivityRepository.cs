using Application.Activities.Contracts;
using Domain.Activities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

internal class ActivityRepository(SocialEventDbContext context) : BaseRepository<Activity>(context), IActivityRepository
{
   public async Task<IEnumerable<Activity>> GetActivitiesAsync(CancellationToken cancellationToken = default)
   {
      return await _context.Activities.ToListAsync(cancellationToken);
   }

   public async Task<Activity?> GetActivityByIdAsync(long id, CancellationToken cancellationToken = default)
   {
      return await _context.Activities
         .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
   }

   public async Task<Activity?> GetActivityByIdAsync(long id, bool isTracking, CancellationToken cancellationToken = default)
   {
      if (isTracking)
      {
         return await _context.Activities
            .AsTracking()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
      }
      else
      {
         return await GetActivityByIdAsync(id, cancellationToken);
      }

     
   }
   
}
