using Domain.Activities;

namespace Infrastructure.Persistence;

public class DbInitializer
{
   public static async Task SeedData(SocialEventDbContext context)
   {
      if (context.Activities.Any()) return; // DB has been seeded

      var activities = new List<Activity>()
      {
         Activity.Create(
                "Past Activity 1",
                DateTime.Now.AddMonths(-2),
                "Activity 2 months ago",
                "drinks",
            
                "London",
                "The Lamb and Flag, 33, Rose Street, Seven Dials, Covent Garden, London, Greater London, England, WC2E 9EB, United Kingdom",
                51.51171665,
                -0.1256611057818921
            ),
            Activity.Create(
                "Past Activity 2",
                DateTime.Now.AddMonths(-1),
                "Activity 1 month ago",
                "culture",
               
                "Paris",
                "Louvre Museum, Rue Saint-Honoré, Quartier du Palais Royal, 1st Arrondissement, Paris, Ile-de-France, Metropolitan France, 75001, France",
                48.8611473,
                2.33802768704666
            ),
            Activity.Create(
                "Future Activity 1",
                DateTime.Now.AddMonths(1),
                "Activity 1 month in future",
                "culture",
                
                "London",
                "Natural History Museum",
                51.496510900000004,
                -0.17600190725447445
            ),
            Activity.Create(
                "Future Activity 2",
                DateTime.Now.AddMonths(2),
                "Activity 2 months in future",
                "music",
              
                "London",
                "The O2",
                51.502936649999995,
                0.0032029278126681844
            ),
            Activity.Create(
                "Future Activity 3",
                DateTime.Now.AddMonths(3),
                "Activity 3 months in future",
                "drinks",
               
                "London",
                "The Mayflower",
                51.501778,
                -0.053577
            ),
            Activity.Create(
                "Future Activity 4",
                DateTime.Now.AddMonths(4),
                "Activity 4 months in future",
                "drinks",
               
                "London",
                "The Blackfriar",
                51.512146650000005,
                -0.10364680647106028
            ),
            Activity.Create(
                "Future Activity 5",
                DateTime.Now.AddMonths(5),
                "Activity 5 months in future",
                "culture",
                
                "London",
                "Sherlock Holmes Museum, 221b, Baker Street, Marylebone, London, Greater London, England, NW1 6XE, United Kingdom",
                51.5237629,
                -0.1584743
            ),
            Activity.Create(
                "Future Activity 6",
                DateTime.Now.AddMonths(6),
                "Activity 6 months in future",
                "music",
                
                "London",
                "Roundhouse, Chalk Farm Road, Maitland Park, Chalk Farm, London Borough of Camden, London, Greater London, England, NW1 8EH, United Kingdom",
                51.5432505,
                -0.15197608174931165
            ),
            Activity.Create(
                "Future Activity 7",
                DateTime.Now.AddMonths(7),
                "Activity 7 months in future",
                "travel",
             
                "London",
                "River Thames, England, United Kingdom",
                51.5575525,
                -0.781404
            ),
            Activity.Create(
                "Future Activity 8",
                DateTime.Now.AddMonths(8),
                "Activity 8 months in future",
                "film",
              
                "London",
                "River Thames, England, United Kingdom",
                51.5575525,
                -0.781404
            )
      };

      context.Activities.AddRange(activities);
      await context.SaveChangesAsync();
   }
}
