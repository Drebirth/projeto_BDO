using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Entities.local;

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
            var local = _bdoContext.Spots.ToList();
            return View(local);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Local local)
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
            //var busca = _bdoContext.Spots.Find(id);
            //return View(busca);
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
        public IActionResult Edit(Local local)
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
        public IActionResult Delete(Local local)
        {
            var l = _bdoContext.Spots.Find(local.Id);

            _bdoContext.Spots.Remove(l);
            _bdoContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}