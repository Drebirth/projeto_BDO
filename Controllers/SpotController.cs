using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Entities.spot;
using projetoBDO.Repository;

namespace projetoBDO.Controllers.spotController
{
    
    [Authorize]
    public class SpotController : Controller
    {
        //private readonly BdoContext _bdoContext;
        private readonly ISpotRepository _repository;

        public SpotController(ISpotRepository repository)
        {
            _repository = repository;
        }

    
        public IActionResult Index(){
            //int pageSize = 5;
            var local = _repository.GetAll();
            return View(local);
            //return View(await Paginacao<Local>.CreateAsync(local, pageNumber ?? 1, pageSize)); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Spot local)
        {
            
            if(ModelState.IsValid)
            {
                //_bdoContext.Spots.Add(local);
                _repository.Create(local);
                //_bdoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public IActionResult Details(long id)
        {
            //var local = _bdoContext.Spots.Include(item => item.Itens).FirstOrDefault(item => item.Id == id);
            var local = _repository.Get(id);
            return View(local);
           
        }

        public IActionResult Edit(long id)
        {
            //var local = _bdoContext.Spots.Find(id);
            var local = _repository.Get(id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        [HttpPost]
        public IActionResult Edit(Spot local)
        {
            //var localBanco = _bdoContext.Spots.Find(local.Id);
            var localBanco = _repository.Get(local.Id);
            localBanco.Nome = local.Nome;
            if(ModelState.IsValid)
            {
                //teste.Nome = local.Nome;
                //_bdoContext.Spots.Update(localBanco);
                _repository.Update(localBanco);
                //_bdoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public IActionResult Delete(long id)
        {
            //var local = _bdoContext.Spots.Find(id);
            var local = _repository.Get(id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        [HttpPost]
        public IActionResult Delete(Spot local)
        {
            //var l = _bdoContext.Spots.Find(local.Id);
            var localBanco = _repository.Get(local.Id);

            //_bdoContext.Spots.Remove(l);
            //_bdoContext.SaveChanges();
            _repository.Delete(localBanco);

            return RedirectToAction("Index");
        }


    }
}