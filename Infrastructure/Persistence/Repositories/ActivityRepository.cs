using Application.Activities.Contracts;
using Domain.Activities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

internal class ActivityRepository(SocialEventDbContext context) : BaseRepository<Activity>(context), IActivityRepository
{
   public async Task<IEnumerable<Activity>> GetActivitiesAsync()
   {
      return await _context.Activities.ToListAsync();
   }
   
}
