using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Repository.Mapas;

namespace projetoBDO.Repository.Mapas
{
    public class MapaRepository : Repository<Mapa>, IMapaRepository
    {
       
        public MapaRepository(BdoContext banco) : base(banco) { }
               
    }
}
