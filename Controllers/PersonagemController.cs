using Microsoft.AspNetCore.Mvc;
using projetoBDO.Entities;
using projetoBDO.Services;

namespace projetoBDO.Controllers
{
    public class PersonagemController : Controller
    {
        private readonly PersonagemService _personagemService;
        

        public PersonagemController(PersonagemService personagemService)
        {
            _personagemService = personagemService;
        }
        // GET: Personagem
        public IActionResult Index()
        {
            var personagens = _personagemService.GetAllPersonagemAsync().Result;
            return View(personagens);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Personagem personagem)
        {
            if (ModelState.IsValid)
            {
               await _personagemService.CreatePersonagemAsync(personagem);
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }
    }
}
