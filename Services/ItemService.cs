using projetoBDO.Entities;
using projetoBDO.Repository.Interfaces;

namespace projetoBDO.Services
{
    public class ItemService
    {
        protected readonly IItemRepository _itemRepository;
        

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetAsync(id);
        }
        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            await _itemRepository.CreateAsync(item);
            return item;
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            await _itemRepository.UpdateAsync(item);
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetAsync(id);
            if (item != null)
            {
                await _itemRepository.DeleteAsync(item);
            }
        }
    }
}
