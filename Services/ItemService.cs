using projetoBDO.Entities;
using projetoBDO.Repository.Itens;

namespace projetoBDO.Services
{
    public class ItemService
    {
        private readonly IItensRepository _itemRepository;
        

        public ItemService(IItensRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItensBySpot(int id)
        {
            return await _itemRepository.GetItemsBySpotIdAsync(id);
        }
        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            var Item = new Item
            {
                Nome = item.Nome,
                Preco = item.Preco,
                Quantidade = 0,
                SpotId = item.SpotId,
                ImagemUrl = item.ImagemUrl
            };
            await _itemRepository.CreateAsync(Item);
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
