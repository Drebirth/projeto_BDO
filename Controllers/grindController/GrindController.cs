using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Context;
using projetoBDO.Entities.grind;
using projetoBDO.Entities.personagem;

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
            var personagens = _bdoContext.Personagens.ToList();//.Where(x => x.User == logado);
            var itens = _bdoContext.Itens.ToList().Where(x => x.SpotId == id);
            Grind grind = new Grind();
            grind.Spot =  mapa;
            grind.Personagens = personagens;
            grind.Itens = itens.ToList();
            grind.DateTime = DateTime.Now;
            return View(grind);
        }

        [HttpPost]
        public IActionResult Create(Grind grind, long id)
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var mapa = _bdoContext.Spots.Find(id);
            var personagem = _bdoContext.Personagens.ToList().Where(x => x.Id == grind.Id);
            var item = _bdoContext.Itens.ToList().Where(x => x.SpotId == id);
           //var teste =  item.First();
            Grind g = new Grind();
            g.User = user;
            g.Personagem = personagem.First();
            g.Spot = mapa; 
            g.DateTime = grind.DateTime;
            double valor = 0;
            //g.Quantidades.Add(grind.Quantidade);
            //g.Quantidade = grind.Quantidade;
            //g.ValorTotal = g.Quantidade * item.First().Preco;
            //teste
            g.Quantidades = grind.Quantidades;
            g.Itens = item.ToList();
            for (int i = 0; i < g.Itens.Count(); i++)
            {   
                valor += grind.Quantidades[i] * g.Itens[i].Preco;
                g.Quantidade += grind.Quantidades[i];
            }
            g.ValorTotal = valor;
            
            
           /*
            g.Itens = grind.Itens;
            
            foreach(var itens in g.Itens){
                valor +=  grind.Quantidade * itens.Preco ;
            }
            g.ValorTotal = valor;*/
            /*for(int i = 0; i < grind.Itens.Count(); i++){
                g.Quantidade = grind.Quantidade;
                g.ValorTotal += g.Quantidade * grind.Itens[i].Preco;
                valor += g.ValorTotal;
                
            }*/
            /*g.Quantidade = grind.Quantidade;
            g.ValorTotal = grind.Quantidade * teste.Preco; */
           
           // grind.Spot = mapa;
           
            _bdoContext.Grinds.Add(g);
            _bdoContext.SaveChanges();
            return RedirectToAction("index");
        }



      
    }
}