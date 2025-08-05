using Microsoft.EntityFrameworkCore;
using PagedList;
using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Paginacao;
using System.Threading.Tasks;

namespace projetoBDO.Repository.Grinds
{
    public class GrindRepository : Repository<Grind>, IGrindRepository
    {
        public GrindRepository(BdoContext context) : base(context)
        {
        }

        //public async Task<IQueryable<Grind>> GetAllAsyncPaginacao()
        //{
        //    var grinds = await _context.Grinds.ToListAsync();
        //    return grinds.AsQueryable();
        //}

        IQueryable<Grind> IGrindRepository.GetAllAsyncPaginacao()
        {
            var grnds = _context.Grinds.AsQueryable();
            return grnds;
        }
    }
}
