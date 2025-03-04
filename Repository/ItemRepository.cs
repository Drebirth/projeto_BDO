using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Repository.Interfaces;

namespace projetoBDO.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {

        public ItemRepository(BdoContext context) : base(context)
        {

        }
    }
   
}
