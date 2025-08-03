using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Entities;

namespace projetoBDO.Repository.Grinds
{
    public class GrindItensRepository : Repository<ItensGrind>, IGrindItensRepository
    {
        public GrindItensRepository(BdoContext context) : base(context)
        {
        }
      

        public async Task<IEnumerable<ItensGrind>> GetFindGrindForId(int id)
        {
            return await _context.ItensGrinds
                .Where(g => g.GrindId == id)
                .ToListAsync();
        }

       
    }
}
