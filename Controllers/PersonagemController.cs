using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projetoBDO.Entities;
using projetoBDO.Models;
using projetoBDO.Services;

namespace projetoBDO.Controllers
{
    [Authorize]
    public class PersonagemController : Controller
    {
        private readonly PersonagemService _personagemService;


        public PersonagemController(PersonagemService personagemService)
        {
            _personagemService = personagemService;
        }
        // GET: Personagem
        public async Task<IActionResult> Index(int page = 1)
        {
            var personagens = await _personagemService.GetPersonagemPagina(page);
            return View(personagens);
            //var personagens = _personagemService.GetAllPersonagemAsync().Result;
            //return View(personagens);
        }



        [HttpGet]
        public IActionResult Create()
        {
            var personagem = new PersonagemViewModel();
            var classes = Enum.GetValues(typeof(ClassesBDO)).Cast<ClassesBDO>().Select(c => new SelectListItem
            {
                Value = c.ToString(),
                Text = c.ToString().Replace("_", " ") // Formata o texto para exibição
            }).ToList();

            ViewBag.Classes = classes; // Passa a lista de classes para a ViewBag

            // Define a classe padrão como a primeira da lista
            return View(new PersonagemViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonagemViewModel personagem)
        {
            if (ModelState.IsValid)
            {
                var resultado = _personagemService.ValidacaoPersonagem(personagem);
                if (!resultado.Result.Success)
                {
                    foreach (var error in resultado.Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                        var classes = Enum.GetValues(typeof(ClassesBDO)).Cast<ClassesBDO>().Select(c => new SelectListItem
                        {
                            Value = c.ToString(),
                            Text = c.ToString().Replace("_", " ") // Formata o texto para exibição
                        }).ToList();

                        ViewBag.Classes = classes;

                        return View(personagem);
                    }
                }


                await _personagemService.CreatePersonagemAsync(personagem);
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        [HttpGet]
        public async Task<IActionResult> EditPersonagem(int id)
        {
            var personagem = await _personagemService.GetPersonagemByIdAsync(id);

            return View(personagem);
        }

        [HttpPost, ActionName("EditPersonagem")]
        public async Task<IActionResult> EditPersonagem(Personagem personagem)
        {
            if (ModelState.IsValid)
            {

                await _personagemService.UpdatePersonagemAsync(personagem);
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var personagem = await _personagemService.GetPersonagemByIdAsync(id);

            return View(personagem);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            await _personagemService.DeletePersonagemAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
