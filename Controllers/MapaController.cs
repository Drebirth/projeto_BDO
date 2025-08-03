using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Entities;
using projetoBDO.Services;
using System.Threading.Tasks;

namespace projetoBDO.Controllers
{
    [Authorize]
    public class MapaController : Controller
    {
        private readonly MapaService _mapaService;

        public MapaController(MapaService mapaService)
        {
            _mapaService = mapaService;
        }

        public async Task<IActionResult> Index()
        {
            var mapas = await _mapaService.GetAllMapasAsync();
            return View(mapas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                await _mapaService.CreateMapaAsync(mapa);
                return RedirectToAction(nameof(Index));
            }
            return View(mapa);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var mapa = await _mapaService.GetMapaPorId(id);
            if (mapa == null)
            {
                return NotFound();
            }
            return View(mapa);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                await _mapaService.UpdateMapaAsync(mapa);
                return RedirectToAction(nameof(Index));
            }
            return View(mapa);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var mapa = await _mapaService.GetMapaPorId(id);
            if (mapa == null)
            {
                return NotFound();
            }
            return View(mapa);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mapaService.DeleteMapaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
