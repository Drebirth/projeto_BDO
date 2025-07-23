using projetoBDO.Context;
using projetoBDO.Entities;

namespace projetoBDO.Repository.Grinds
{
    public class GrindRepository : Repository<Grind>, IGrindRepository
    {
        public GrindRepository(BdoContext context) : base(context)
        {
        }
    }
}
