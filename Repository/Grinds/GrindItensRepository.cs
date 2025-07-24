using projetoBDO.Context;
using projetoBDO.Entities;

namespace projetoBDO.Repository.Grinds
{
    public class GrindItensRepository : Repository<ItensGrind>, IGrindItensRepository
    {

        public GrindItensRepository(BdoContext context) : base(context)
        {
        }
        // You can add any specific methods for ItensGrind here if needed
        // For example, methods to get items by GrindId or other specific queries
    }
}
