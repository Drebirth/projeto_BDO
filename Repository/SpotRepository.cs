using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Paginacao;
using projetoBDO.Repository.Interfaces;

namespace projetoBDO.Repository
{
    public class SpotRepository : Repository<Spot>, ISpotRepository
    {
        
        public SpotRepository(BdoContext context) : base(context)
        {
            
        }

        //public Paginacao<Spot> GetSpots(Paginacao paginacao)
        //{
        //    var spots = GetAll().OrderBy(x => x.Id).AsQueryable();
        //    var spotsOrdenados = Paginacao<Spot>

        //}
    }
}
