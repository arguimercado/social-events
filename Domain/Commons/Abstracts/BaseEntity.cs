using System;

namespace Domain.Commons.Abstracts;

public abstract class BaseEntity
{
   public string Id { get; private set; }
   public DateTime CreatedOn { get; private set; }
   public DateTime LastModifiedOn { get; private set; }

   protected BaseEntity() {
      Id = Guid.NewGuid().ToString();
      CreatedOn = DateTime.UtcNow;
      LastModifiedOn = DateTime.UtcNow;
   }
   
   protected BaseEntity(string id)
   {
      Id = id;
      CreatedOn = DateTime.UtcNow;
      LastModifiedOn = DateTime.UtcNow;
   }

   
}
