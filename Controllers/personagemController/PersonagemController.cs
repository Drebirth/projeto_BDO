using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Context;
using projetoBDO.Entities.personagem;

namespace projetoBDO.Controllers.personagemController
{
    [Authorize]
    public class PersonagemController: Controller
    {
        private readonly BdoContext _bdoContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PersonagemController(BdoContext bdoContext, IHttpContextAccessor httpContextAccessor)
        {
            _bdoContext = bdoContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var logado = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var personagens = _bdoContext.Personagens.ToList().Where(x => x.User == logado);
            return View(personagens);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Personagem personagem)
        {
            string usuario = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
          if(ModelState.IsValid)
            {
                personagem.User = usuario;
                _bdoContext.Personagens.Add(personagem);
                _bdoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        public IActionResult Edit(long id){
            var personagem = _bdoContext.Personagens.Find(id);
            if(personagem == null){
                return NotFound();
            }
            return View(personagem);
        }

        [HttpPost]
        public IActionResult Edit(Personagem personagem)
        {
            var personagemEditado = _bdoContext.Personagens.Find(personagem.Id);
            personagemEditado.Nome = personagem.Nome;
            personagemEditado.Classe = personagem.Classe;
            personagemEditado.PA = personagem.PA;
            personagem.DP = personagem.DP;
            personagem.Level = personagem.Level;
           // if(ModelState.IsValid)
            //{
                
                _bdoContext.Personagens.Update(personagemEditado);
                _bdoContext.SaveChanges();
                return RedirectToAction("Index");
            //}
            //return View(personagem);
        }

        public IActionResult Delete(long id)
        {
            var usuario = _bdoContext.Personagens.Find(id);
            if(usuario == null){
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(Personagem personagem){
            
            var personagemDelete = _bdoContext.Personagens.Find(personagem.Id);
            _bdoContext.Remove(personagemDelete);
            _bdoContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}