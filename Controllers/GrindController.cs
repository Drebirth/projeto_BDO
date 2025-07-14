using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Models;

namespace projetoBDO.Controllers.grindController
{
    [Authorize]
    public class GrindController : Controller
    {
        private readonly BdoContext _bdoContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GrindController(BdoContext bdoContext, IHttpContextAccessor httpContextAccessor)
        {
            _bdoContext = bdoContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            //Só de efetuar o TOList ele carrega no index??
            string logado = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var personagens = _bdoContext.Personagens.ToList();
            var grind = _bdoContext.Grinds.ToList().Where(x => x.User == logado);
            var mapas = _bdoContext.Spots.ToList();
        
            return View(grind);
        }

        public IActionResult Create(long id)
        {        
            string logado = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var mapa = _bdoContext.Spots.Find(id);
            var personagens = _bdoContext.Personagens.ToList().Where(x => x.User == logado);
            var itens = _bdoContext.Itens.ToList().Where(x => x.SpotId == id);

           if(personagens.Count() == 0){
                return RedirectToAction("Create","Personagem");
           }if(itens.Count() == 0)
           {
            return RedirectToAction("Create","Item");
           }
           else{
            Grind grind = new Grind();
            grind.Spot =  mapa;
            grind.Personagens = personagens.ToList();
            grind.Itens = itens.ToList();
            grind.DateTime = DateTime.Now;
            return View(grind);
           }
        }

        [HttpPost]
        public IActionResult Create(Grind grind,long id)
        {
            Grind g = new Grind();
            var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var mapa = _bdoContext.Spots.Find(id);
            var personagems = _bdoContext.Personagens.ToList().Where(x => x.Nome == grind.PersonagemNome);
            //var personagem = _bdoContext.Personagens.FromSql($"Select * from Personagens where {grind.Personagem.Nome} like '%Personagens.Nome%'");
          
                var personagem = personagems.FirstOrDefault();
                grind.Personagem = personagem;
                if(grind.Personagem == null)
                {
                    ModelState.AddModelError("PersonagemNome","Personagem não localizado, favor informar um nome de personagem valido");
                }
               
            var item = _bdoContext.Itens.ToList().Where(x => x.SpotId == id);
            decimal valor = 0;
            int quantidade = 0;
            for(int i=0; i< grind.Itens.Count(); i ++)
            {
                if(grind.Itens[i].Quantidade <= 0)
                {
                    ModelState.AddModelError("Itens.Quantidade","A quantidade do item não pode ser 0 ou menor!");
                }

            }

            if(ModelState.IsValid)
            {
                for (int i = 0; i < grind.Itens.Count(); i++)
                {   
                    
                    valor += grind.Itens[i].Quantidade * grind.Itens[i].Preco;
                    quantidade += grind.Itens[i].Quantidade;
                }                                   
                g.User = user;
                g.Personagem = personagem;
                g.Spot = mapa; 
                g.DateTime = grind.DateTime;
                g.PersonagemNome = grind.PersonagemNome;
                //g.ValorTotal = valor;                                                                                                      
                g.ValorTotal = Math.Round(valor,10);
                g.Quantidade = quantidade;
                _bdoContext.Grinds.Add(g);
                _bdoContext.SaveChanges();
                return RedirectToAction("index"); 
            }
            //Response.Redirect(Request.GetDisplayUrl());
            return View(grind);
        }
        
        public ActionResult DeleteGrind(long id)
        {
            var grind = _bdoContext.Grinds.Find(id);
            if(grind is null)
            {
                return NotFound();
            }
            return View(grind);   
        }

        [HttpPost]
        public ActionResult DeleteGrind(Grind grind)
        {
            var grindParaDeletar = _bdoContext.Grinds.Find(grind.Id);
            _bdoContext.Grinds.Remove(grindParaDeletar);
            _bdoContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


     
            
            
          
        
    }
}