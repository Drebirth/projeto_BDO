using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projetoBDO.Context;
using projetoBDO.Entities.grind;
using projetoBDO.Entities.personagem;
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
            var personagem = _bdoContext.Personagens.ToList().Where(x => x.Nome == grind.Personagem.Nome);
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
                g.User = user;
                g.Personagem = personagem.First();
                g.Spot = mapa; 
                g.DateTime = grind.DateTime;
                for (int i = 0; i < grind.Itens.Count(); i++)
                {   
                    
                    valor += grind.Itens[i].Quantidade * grind.Itens[i].Preco;
                    quantidade += grind.Itens[i].Quantidade;
                }                                                                                                                                         
                g.ValorTotal = Math.Round(valor,2);
                g.Quantidade = quantidade;
                 _bdoContext.Grinds.Add(g);
                _bdoContext.SaveChanges();
                return RedirectToAction("index"); 
            }
            //Response.Redirect(Request.GetDisplayUrl());
            return View(grind);
        }
        
       /* [HttpPost]
        public IActionResult Create(Grind grind, long id)
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var mapa = _bdoContext.Spots.Find(id);
            var personagem = _bdoContext.Personagens.ToList().Where(x => x.Nome == grind.Personagem.Nome);
            var item = _bdoContext.Itens.ToList().Where(x => x.SpotId == id);
            double valor = 0;
            
            if(grind.Personagens.Count() == null || grind.Personagens.Count() == 0){
                ModelState.AddModelError("Personagem","Você precisa selecionar um personagem!");
            }else{

            
            Grind g = new Grind();
            g.User = user;
            g.Personagem = personagem.First();
            g.Spot = mapa; 
            g.DateTime = grind.DateTime;
            
            
            for (int i = 0; i < grind.Itens.Count(); i++)
            {   
                valor += grind.Itens[i].Quantidade * grind.Itens[i].Preco;
                g.Quantidade += grind.Itens[i].Quantidade;
            }                                                                                                                                         
            g.ValorTotal = valor;
            

            
            _bdoContext.Grinds.Add(g);
            _bdoContext.SaveChanges();
            return RedirectToAction("index"); 
            }
            
            return View(grind);
        }*/
            
            
            
          
        
    }
}