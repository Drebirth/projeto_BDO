using Microsoft.AspNetCore.Mvc;
using projetoBDO.Entities;
using projetoBDO.Models;
using projetoBDO.Services;

namespace projetoBDO.Controllers
{
    public class ItemController : Controller
    {

        private readonly ItemService _itemService;
        private readonly SpotService _spotService;

        public ItemController(ItemService itemService, SpotService spotService)
        {
            _itemService = itemService;
            _spotService = spotService;
        }


        public IActionResult Index()
        {
            // This is a blocking call, consider using async/await in production code
            var itens = _itemService.GetAllItemsAsync().Result;
            return View(itens);
        }

        //[HttpGet("id")]
        public IActionResult Create(int id)
        {   
            var spot = _spotService.GetSpotPorId(id).Result;
            Item item = new Item
            {
                SpotId = spot.Id
                
            };
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Item item)
        {

            if (ModelState.IsValid)
            {
                await _itemService.CreateItemAsync(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
