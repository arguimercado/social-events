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

   public async Task<Activity?> GetActivityByIdAsync(string id, CancellationToken cancellationToken = default)
   {
      return await _context.Activities
         .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
   }
   
}
