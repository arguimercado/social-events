using Application.Commons.Contracts;
using Domain.Activities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SocialEventDbContext : DbContext, IUnitOfWork
{
   public DbSet<Activity> Activities { get; set; }

   public SocialEventDbContext(DbContextOptions<SocialEventDbContext> options)
       : base(options)
   {

   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Activity>().ToTable("Activities");
      modelBuilder.Entity<Activity>(opt =>
      {
         opt.HasKey(a => a.Id);
         opt.Property(a => a.Id).ValueGeneratedOnAdd();
         opt.Property(a => a.Title).IsRequired().HasMaxLength(250);
         opt.Property(a => a.Description).HasMaxLength(1000);
         opt.Property(a => a.City).HasMaxLength(500);
         opt.Property(a => a.Venue).HasMaxLength(500);
         opt.Property(a => a.Date).IsRequired();
         opt.Property(a => a.Category).IsRequired().HasMaxLength(100);
         opt.Property(a => a.IsCancelled).IsRequired();
         opt.Property(a => a.Latitude).IsRequired();
         opt.Property(a => a.Longitude).IsRequired();
         opt.Property(a => a.CreatedOn).IsRequired();
         opt.Property(a => a.LastModifiedOn).IsRequired();

         
      });
   }

   public async Task<int> CommitChangesAsync()
   {
      return await SaveChangesAsync();
   }
}
