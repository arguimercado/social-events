using Application.Commons.Contracts;
using Domain.Commons.Abstracts;

namespace Infrastructure.Persistence.Repositories;

internal class BaseRepository<T>(SocialEventDbContext context) : IBaseRepository<T> where T : AggregateRoot
{
   protected readonly SocialEventDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

   public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
       
    }

    public void Delete(T entity)
    {   
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            
        }
    }
} 
