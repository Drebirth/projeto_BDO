using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Entities.item;
using projetoBDO.Entities.local;
using projetoBDO.Context;
using Microsoft.EntityFrameworkCore;

namespace projetoBDO.Controllers.itemController
{
    public class ItemController: Controller
    {
        
        private readonly BdoContext _bdoContext;

        public ItemController(BdoContext bdoContext){
            _bdoContext = bdoContext;
        }

        public IActionResult Index(long id){
            var lista = _bdoContext.Itens.ToList().Where(x => x.SpotId == id);
            var local = _bdoContext.Spots.Find(id);
            return View(lista);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item, long id)
        {
          //  var teste = _bdoContext.Spots.FromSql($"SELECT * FROM spots where Nome = {item.Spot}");
            
            var teste = _bdoContext.Spots.Find(id);
            Item i = new Item();
                 //item.Spot = teste;
                 //item.SpotId = id;
                // _bdoContext.Itens.Add(item);
                // _bdoContext.SaveChanges();
                // return RedirectToAction("Index");
            //FromSql($"SELECT * FROM SPOTS WHERE Nome = {item.Spot}");
            if(ModelState.IsValid)
            {
                 i.Nome = item.Nome;
                 i.Preco = item.Preco;
                 i.Spot = teste;
                _bdoContext.Itens.Add(i);
                _bdoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        
    }
}