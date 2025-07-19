using System;
using Domain.Commons.Abstracts;

namespace Domain.Activities;

public class Activity : AggregateRoot
{
  
   public static Activity Create(string title, DateTime date, string description, string category, bool isCancelled, string city, string venue, double latitude, double longitude)
   {
      return new Activity(title, date, description, category, isCancelled, city, venue, latitude, longitude);
   }

   protected Activity(string title, DateTime date, string description, string category, bool isCancelled, string city, string venue, double latitude, double longitude) : base(0)
   {
      Title = title;
      Date = date;
      Description = description;
      Category = category;
      IsCancelled = isCancelled;
      City = city;
      Venue = venue;
      Latitude = latitude;
      Longitude = longitude;

   }
   public string Title { get; private set; } = default!;

   public DateTime Date { get; private set; }

   public string Description { get; private set; } = default!;

   public string Category { get; private set; } = default!;

   public bool IsCancelled { get; private set; }
   //location props
   public string City { get; private set; } = default!;

   public string Venue { get; private set; } = default!;

   public double Latitude { get; private set; }
   public double Longitude { get; private set; }
}
