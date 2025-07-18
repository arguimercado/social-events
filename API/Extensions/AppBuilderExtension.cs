using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class AppBuilderExtension
{
   public static async Task InitializeDatabaseAsync(this WebApplication app)
   {
      using var scope = app.Services.CreateScope();
      try
      {
         var context = scope.ServiceProvider.GetRequiredService<SocialEventDbContext>();
         await context.Database.MigrateAsync();
         await DbInitializer.SeedData(context);

      }
      catch (Exception ex)
      {
         var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
         logger.LogError(ex, "An error occurred while initializing the database.");
         // Log the exception (consider using a logging framework)
         Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
      }
   }

}
