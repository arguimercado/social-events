
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Domain.Commons.Abstracts;
using Infrastructure.Persistence;

namespace Infrastructure;

public static class DependencyInjection
{
   public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<SocialEventDbContext>(options =>
          options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<SocialEventDbContext>());

      return services;
   }

}
