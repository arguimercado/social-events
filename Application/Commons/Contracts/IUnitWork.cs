namespace Application.Commons.Contracts;

public interface IUnitOfWork
{
   Task<int> CommitChangesAsync(CancellationToken cancellationToken = default);
}
