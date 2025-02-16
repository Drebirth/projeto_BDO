using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Entities.item;
using projetoBDO.Entities.local;
using projetoBDO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace projetoBDO.Controllers.itemController
{
    
    [Authorize]
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
            var teste = _bdoContext.Spots.Find(id);
            if(item.Preco <= 0)
            {
                ModelState.AddModelError("Preco","O valor informado não pode ser 0 ou menor");
            }
            Item i = new Item();
            if(ModelState.IsValid)
            {
                 i.Nome = item.Nome;
                 i.Preco = Math.Round(item.Preco,4);
                 i.Spot = teste;
                _bdoContext.Itens.Add(i);
                _bdoContext.SaveChanges();
                return RedirectToAction(nameof(Index), "Local");
            }
            return View(item);
        }

        public IActionResult Edit(long id)
        {
            var item = _bdoContext.Itens.Find(id);
            if(item == null){
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            var itemAtt = _bdoContext.Itens.Find(item.Id);
            itemAtt.Nome = item.Nome;
            itemAtt.Preco = item.Preco;
            if(ModelState.IsValid)
            {
                //itemAtt = item;
                _bdoContext.Itens.Update(itemAtt);
                _bdoContext.SaveChanges();
                return RedirectToAction(nameof(Index), "Local");
                //return RedirectToAction("Index","LocalController", new { id = item.Id });
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
           var ItemDeletado = _bdoContext.Itens.Find(id);
           if(ItemDeletado is null)
           {
                return NotFound();
           }

           _bdoContext.Remove(ItemDeletado);
           _bdoContext.SaveChanges();
          return RedirectToAction("Index","ItemController");
        }

        
    }
}