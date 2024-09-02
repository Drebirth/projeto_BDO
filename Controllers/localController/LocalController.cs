using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetoBDO.Context;
using projetoBDO.Entities.local;

namespace projetoBDO.Controllers.localController
{
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
             /*   
                _bdoContext.Spots.Add(local);
                _bdoContext.SaveChanges();
                return RedirectToAction("Index");
                */
            
            if(ModelState.IsValid)
            {
                //local.Nome.ToUpper();
                _bdoContext.Spots.Add(local);
                _bdoContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }


    }
}