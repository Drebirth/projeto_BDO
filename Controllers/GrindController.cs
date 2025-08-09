using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public  async Task<IActionResult> Index(int page = 1)
        {
            var grinds = await _grindService.GetGrindsPagina(page);
            return View(grinds);
        }
   

        //public async Task<IActionResult> Index2(int page = 1, int pageSize = 10)
        //{
        //    var allItems = await _grindService.GetAllAsync();  // retorna List<Grind>

        //    var totalItems = allItems.Count();
        //    var paginacao = allItems
        //        .OrderBy(c => c.Id)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        //    ViewBag.CurrentPage = page;

        //    return View(paginacao);
        //}

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
