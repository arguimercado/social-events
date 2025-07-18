
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Infrastructure.Persistence;
using Application.Commons.Contracts;
using Application.Activities.Contracts;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure;

public static class DependencyInjection
{
   public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<SocialEventDbContext>(options =>
         {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         });

      services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<SocialEventDbContext>());
      services.AddScoped<IActivityRepository, ActivityRepository>();
      return services;
   }

}
