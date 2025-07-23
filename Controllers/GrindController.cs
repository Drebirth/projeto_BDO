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
        private readonly SpotService _spotService;
        private readonly ItemService _item;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BdoContext _context;


        public GrindController(GrindService grindService, SpotService spotService, ItemService item, IHttpContextAccessor httpContextAccessor,BdoContext context)
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

        public IActionResult Create(int id)
        {
            var spotd =  _spotService.GetSpotPorId(id);
            var itens = _item.GetAllItemsAsync().Result.Where(I => I.SpotId == id).ToList();
            //var logado = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;
            var logado = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var personagens = _context.Personagens.Where(p => p.NomeDeFamilia == logado).ToList();
            GrindViewModel model = new GrindViewModel
            {
                SpotId = id,
                SpotNome = spotd.Result.Nome,
                //Itens = (List<ItensGrind>)spotd.Result.Itens,
                Itens = itens,
                Personagens = personagens,
                
                

            };
            
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(GrindViewModel model)
        {
            if(ModelState.IsValid)
            {
                decimal subtotal = 0;
                foreach (var item in model.Itens)
                {
                    subtotal += subtotal + (item.Preco * model.Quantidade);
                }

               await  _grindService.CreateAsync(new Grind
                {
                    PersonagemId = model.PersonagemId,
                    SpotId = model.SpotId,
                    ValorTotal = subtotal,
                    Mapa = model.SpotNome,
                    

               });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
