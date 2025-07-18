namespace Domain.Commons.Abstracts;

public interface IUnitOfWork
{
   Task<int> CommitChangesAsync();
}
