using System;
using Domain.Activities;

namespace Application.Activities.Dtos;

public record ActivityDto
{
   public ActivityDto(Activity activity)
   {
      Id = activity.Id;
      Title = activity.Title;
      Date = activity.Date;
      Description = activity.Description;
      Category = activity.Category;
      IsCancelled = activity.IsCancelled;
      City = activity.City;
      Venue = activity.Venue;
      Latitude = activity.Latitude;
      Longitude = activity.Longitude;
   }
   public ActivityDto(long id, string title, DateTime date, string description, string category, bool isCancelled, string city, string venue, double latitude, double longitude)
   {
      Id = id;
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
   
   public long Id { get; }
   public string Title { get; } 
   public DateTime Date { get; }
   public string Description { get; }
   public string Category { get; } 
   public bool IsCancelled { get; }
   public string City { get; } 
   public string Venue { get; }
   public double Latitude { get; }
   public double Longitude { get; }
}
