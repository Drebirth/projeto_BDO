using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Repository.Spots;

namespace projetoBDO.Repository.Spots
{
    public class SpotRepository : Repository<Spot>, ISpotRepository
    {
       
        public SpotRepository(BdoContext banco) : base(banco) { }
               
    }
}
