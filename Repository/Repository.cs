using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;

namespace projetoBDO.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly BdoContext _context;

    public Repository(BdoContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {       
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetAsync(int id)
    {        
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}