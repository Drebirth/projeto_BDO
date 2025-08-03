using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Models;
using projetoBDO.Services;
using System.Security.Claims;

namespace projetoBDO.Controllers
{
    [Authorize]
    public class GrindController : Controller
    {

        private readonly GrindService _grindService;
        private readonly IHttpContextAccessor _httpContextAccessor;
     


        public GrindController(GrindService grindService,   IHttpContextAccessor httpContextAccessor)
        {
            _grindService = grindService;
            _httpContextAccessor = httpContextAccessor;
           
        }

        // GET: Grind
        public IActionResult Index()
        {
            var grinds = _grindService.GetAllAsync().Result;
            return View(grinds);
        }

        public async Task<IActionResult> Create(int id)
        {
            // Buscar o usuário logado
            var logado = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var model = await _grindService.MontarGrindViewModelAsync(id, logado);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GrindViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _grindService.CreateAsync(new Grind
                {
                    PersonagemId = (int)model.PersonagemId,
                    SpotId = model.MapaId,
                    Mapa = model.MapaNome,

                }, model.Itens);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var grind = await _grindService.GetByIdAsync(id);
           return View(grind);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _grindService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
