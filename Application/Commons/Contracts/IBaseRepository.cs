using Domain.Commons.Abstracts;

namespace Application.Commons.Contracts;

public interface IBaseRepository<T> where T : AggregateRoot
{
   void Add(T entity);
   void Update(T entity);
   void Delete(T entity);

}
