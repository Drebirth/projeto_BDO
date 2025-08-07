using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Entities;

namespace projetoBDO.Repository.Itens
{
    public class ItemRepository : Repository<Item>, IItensRepository
    {
        public ItemRepository(BdoContext context) : base(context)
        {
        }

        public IQueryable<Item> GetAllAsyncPaginacao()
        {
            var itens = _context.Itens.AsQueryable();
            return itens;
        }

        public async Task<IEnumerable<Item>> GetItemsBySpotIdAsync(int spotId)
        {
            return await _context.Itens
                .Where(i => i.SpotId == spotId)
                .ToListAsync();
        }
    }
}
