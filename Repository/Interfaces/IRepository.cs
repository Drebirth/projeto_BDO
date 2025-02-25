namespace projetoBDO.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(long id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
