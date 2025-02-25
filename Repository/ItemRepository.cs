using projetoBDO.Context;
using projetoBDO.Entities.item;
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
