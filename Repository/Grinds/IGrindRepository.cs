using PagedList;
using projetoBDO.Entities;
using projetoBDO.Paginacao;

namespace projetoBDO.Repository.Grinds
{
    public interface IGrindRepository : IRepository<Grind>
    {
    IQueryable<Grind> GetAllAsyncPaginacao();
    }
}
