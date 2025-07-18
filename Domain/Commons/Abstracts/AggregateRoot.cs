using System;

namespace Domain.Commons.Abstracts;

public abstract class AggregateRoot
{
   public string Id { get; private set; }
   public DateTime CreatedOn { get; private set; }
   public DateTime LastModifiedOn { get; private set; }

   protected AggregateRoot() {
      Id = Guid.NewGuid().ToString();
      CreatedOn = DateTime.UtcNow;
      LastModifiedOn = DateTime.UtcNow;
   }
   
   protected AggregateRoot(string id)
   {
      Id = id;
      CreatedOn = DateTime.UtcNow;
      LastModifiedOn = DateTime.UtcNow;
   }

   
}
