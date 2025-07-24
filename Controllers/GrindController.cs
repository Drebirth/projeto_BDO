using Microsoft.AspNetCore.Mvc;
using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Models;
using projetoBDO.Services;
using System.Security.Claims;

namespace projetoBDO.Controllers
{
    public class GrindController : Controller
    {

        private readonly GrindService _grindService;
        private readonly MapaService _spotService;
        private readonly ItemService _item;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BdoContext _context;


        public GrindController(GrindService grindService, MapaService spotService, ItemService item, IHttpContextAccessor httpContextAccessor,BdoContext context)
        {
            _grindService = grindService;
            _spotService = spotService;
            _item = item;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        // GET: Grind
        public IActionResult Index()
        {
            return View();
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
            if(ModelState.IsValid)
            {
                // Calcula o subtotal usando o service
               decimal subtotal = _grindService.CalcularSubTotal(model.Itens);

               
                await  _grindService.CreateAsync(new Grind
                {
                    PersonagemId = model.PersonagemId,
                    SpotId = model.MapaId,
                    ValorTotal = subtotal,
                    Mapa = model.MapaNome,
                   
                }, model.Itens);
                //await _grindService.CreateAsyncItens(model.Itens, model.Quantidade);

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
