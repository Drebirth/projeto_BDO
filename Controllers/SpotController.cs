using Microsoft.AspNetCore.Mvc;
using projetoBDO.Entities;
using projetoBDO.Services;
using System.Threading.Tasks;

namespace projetoBDO.Controllers
{
    public class SpotController : Controller
    {
        private readonly SpotService _service;
        private readonly ItemService _itemService;

        public SpotController(SpotService service, ItemService itemService)
        {
            _service = service;
            _itemService = itemService;
        }


        public async Task<IActionResult> Index()
        {
            var spots = await _service.GetAllSpotsAsync();
            return View(spots);
        }

        public IActionResult Create()
        {
           var spot = new Spot
            {
                Itens = (ICollection<Item>)_itemService.GetAllItemsAsync().Result // This is a blocking call, consider using async/await in production code
           };
            return View(spot);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Spot spot)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateSpotAsync(spot);
                return RedirectToAction("Index");
            }
            return View(spot);
        }

        public async Task<IActionResult> Details(int id)
        {
            var spot = await _service.GetSpotPorId(id);
            if (spot == null)
            {
                return NotFound();
            }
            return View(spot);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var spot = await _service.GetSpotPorId(id);
            if (spot == null)
            {
                return NotFound();
            }
            return View(spot);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Spot spot)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateSpotAsync(spot);
                return RedirectToAction("Index");
            }
            return View(spot);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var spot = await _service.GetSpotPorId(id);
            if (spot == null)
            {
                return NotFound();
            }
            return View(spot);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.DeleteSpotAsync(id);
                return RedirectToAction("Index");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
