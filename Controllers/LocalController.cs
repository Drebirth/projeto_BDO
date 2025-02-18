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

namespace projetoBDO.Controllers.localController
{
    
    [Authorize]
    public class LocalController : Controller
    {
        private readonly BdoContext _bdoContext;

        public LocalController(BdoContext bdodb)
        {
            _bdoContext = bdodb;
        }

    
        public IActionResult Index(){
            //int pageSize = 5;
            var local = _bdoContext.Spots;
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
                _bdoContext.Spots.Add(local);
                _bdoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public IActionResult Details(long id)
        {
            var local = _bdoContext.Spots.Include(item => item.Itens)
            .FirstOrDefault(item => item.Id == id);
            return View(local);
           
        }

        public IActionResult Edit(long id)
        {
            var local = _bdoContext.Spots.Find(id);
            if(local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        [HttpPost]
        public IActionResult Edit(Spot local)
        {
            var localBanco = _bdoContext.Spots.Find(local.Id);
            localBanco.Nome = local.Nome;
            if(ModelState.IsValid)
            {
                //teste.Nome = local.Nome;
                _bdoContext.Spots.Update(localBanco);
                _bdoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public IActionResult Delete(long id)
        {
            var local = _bdoContext.Spots.Find(id);
            if(local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        [HttpPost]
        public IActionResult Delete(Spot local)
        {
            var l = _bdoContext.Spots.Find(local.Id);

            _bdoContext.Spots.Remove(l);
            _bdoContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}