using projetoBDO.Entities;

namespace projetoBDO.Repository.Itens
{
    public interface IItensRepository : IRepository<Item>
    {
        // Define additional methods specific to Item repository if needed
        // For example:
         Task<IEnumerable<Item>> GetItemsBySpotIdAsync(int spotId);
         IQueryable<Item> GetAllAsyncPaginacao();
        // Task<Item> GetItemByNameAsync(string name);
    }
    
}
