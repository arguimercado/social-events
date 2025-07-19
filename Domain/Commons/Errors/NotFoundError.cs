using FluentResults;

namespace Domain.Commons.Errors;

public class NotFoundError : Error
{
    public NotFoundError(string message) : base(message)
    {
        Metadata.Add("ErrorType", "NotFound");
    }

   public NotFoundError(string message, Exception exception) : base(message)
   {
      Metadata.Add("ErrorType", "NotFound");
      Metadata.Add("Exception", exception);
   }
}
