using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Entities.item;
using projetoBDO.Entities.spot;
using projetoBDO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using projetoBDO.Repository.Interfaces;
using projetoBDO.Models;

namespace projetoBDO.Controllers.itemController
{

    [Authorize]
    public class ItemController: Controller
    {
        private readonly IItemRepository _repository;
        private readonly ISpotRepository _spot;

        public ItemController(IItemRepository itemRepository, ISpotRepository spot)
        {
            _repository = itemRepository;
            _spot = spot;
        }
        
        public IActionResult Index(long id){
            //var lista = _bdoContext.Itens.ToList().Where(x => x.SpotId == id);
            //var local = _bdoContext.Spots.Find(id);
            var lista = _repository.GetAll().Where(x => x.SpotId == id);
            var local = _spot.Get(id);
            return View(lista);
        }



        public IActionResult Create()
        {
            SpotItemViewModel spotitemView = new SpotItemViewModel();
            spotitemView.spots = (List<Spot>?)_spot.GetAll();
            return View(spotitemView);
        }

        [HttpPost]
        public IActionResult Create(SpotItemViewModel teste)
        {
            var spot = _spot.Get((long)teste.SpotId);
            Item i = new Item();

            i.Spot = spot;
            i.Nome = teste.item.Nome;
            i.Preco = teste.item.Preco;

            _repository.Create(i);
            return RedirectToAction("Index");
        }

        //public IActionResult Create()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Item item, long id)
        //{            
        //    //var teste = _bdoContext.Spots.Find(id);
        //    var teste = _spot.Get(id);
        //    if (item.Preco <= 0)
        //    {
        //        ModelState.AddModelError("Preco","O valor informado não pode ser 0 ou menor");
        //    }
        //    Item i = new Item();
        //    if(ModelState.IsValid)
        //    {
        //         i.Nome = item.Nome;
        //         i.Preco = Math.Round(item.Preco,4);
        //         //i.Spot = teste;
        //        //_bdoContext.Itens.Add(i);
        //        _repository.Create(i);
        //        //_bdoContext.SaveChanges();
        //        return RedirectToAction(nameof(Index), "Local");
        //    }
        //    return View(item);
        //}

        public IActionResult Edit(long id)
        {
            //var item = _bdoContext.Itens.Find(id);
            var item = _repository.Get(id);
            if (item == null){
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            //var itemAtt = _bdoContext.Itens.Find(item.Id);
            var itemAtt = _repository.Get(item.Id);
            itemAtt.Nome = item.Nome;
            itemAtt.Preco = item.Preco;
            if(ModelState.IsValid)
            {
                //itemAtt = item;
                //_bdoContext.Itens.Update(itemAtt);
                _repository.Update(itemAtt);
                //_bdoContext.SaveChanges();
                return RedirectToAction(nameof(Index), "Local");
                //return RedirectToAction("Index","LocalController", new { id = item.Id });
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
           //var ItemDeletado = _bdoContext.Itens.Find(id);
           var ItemDeletado = _repository.Get(id);
            if (ItemDeletado is null)
           {
                return NotFound();
           }

           //_bdoContext.Remove(ItemDeletado);
           //_bdoContext.SaveChanges();
          _repository.Delete(ItemDeletado);
            return RedirectToAction("Index","ItemController");
        }

        
    }
}