using projetoBDO.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projetoBDO.Repository.Mapas
{
    public interface IMapaRepository
    {
        Task<IEnumerable<Mapa>> GetAllAsync();
        Task<Mapa> GetAsync(int id);
        Task CreateAsync(Mapa mapa);
        Task UpdateAsync(Mapa mapa);
        Task DeleteAsync(Mapa mapa);
        IQueryable<Mapa> GetAllAsyncPaginacao();
    }
}
