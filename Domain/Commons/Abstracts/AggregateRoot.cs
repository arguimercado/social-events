using System;

namespace Domain.Commons.Abstracts;

public abstract class AggregateRoot
{
   public long Id { get; private set; }
   public DateTime CreatedOn { get; private set; }
   public DateTime LastModifiedOn { get; private set; }

   protected AggregateRoot()
   {
      Id = 0;
      CreatedOn = DateTime.UtcNow;
      LastModifiedOn = DateTime.UtcNow;
   }

   protected AggregateRoot(long id)
   {
      Id = id;
      CreatedOn = DateTime.UtcNow;
      LastModifiedOn = DateTime.UtcNow;
   }
   
   protected void SetLastModifiedOn(DateTime dateTime)
   {
      LastModifiedOn = dateTime;
   }
   
}
