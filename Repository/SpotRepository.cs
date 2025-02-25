using projetoBDO.Context;
using projetoBDO.Entities.spot;
using projetoBDO.Repository.Interfaces;

namespace projetoBDO.Repository
{
    public class SpotRepository : Repository<Spot>, ISpotRepository
    {
        
        public SpotRepository(BdoContext context) : base(context)
        {
            
        }

       
    }
}
