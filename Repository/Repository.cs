using projetoBDO.Context;
using projetoBDO.Repository.Interfaces;

namespace projetoBDO.Repository;

public class Repository<T> : IRepository<T> where T :class
{
    protected readonly BdoContext _context;

    public Repository(BdoContext context)
    {
        _context = context;
    }

    public T Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public T Delete(T entity)
    {
       _context.Set<T>().Remove(entity);
        _context.SaveChanges();
        return entity;
    }

    public T? Get(long id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return entity;
    }
}