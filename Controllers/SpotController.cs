using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoBDO.Context;
using projetoBDO.Entities;
using projetoBDO.Paginacao;
using projetoBDO.Repository.Interfaces;

namespace projetoBDO.Controllers.spotController
{

    [Authorize]
    public class SpotController : Controller
    {
        private readonly ISpotRepository _repository;

        public SpotController(ISpotRepository repository)
        {
            _repository = repository;
        }

        public  IActionResult Index2(int? pageNumber)
        {
            int pageSize = 10;
            var spots = _repository.GetAll();
            //return View(await PaginatedList<Spot>.CreateAsync((IQueryable<Spot>)spots.AsQueryable(), pageNumber ?? 1, pageSize));
            //var items = await PaginatedList<projetoBDO.Entities.Spot>.CreateAsync(spots.AsQueryable(), pageIndex, pageSize);
            var paginatedList =  PaginatedList<Spot>.Create((IQueryable<Spot>)spots.AsQueryable(), pageNumber ?? 1, pageSize);
            return View(paginatedList);

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
                _repository.Create(local);
     
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public IActionResult Details(long id)
        {
            
            var local = _repository.Get(id);
            return View(local);
           
        }

        public IActionResult Edit(long id)
        {
            
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
            
            var localBanco = _repository.Get(local.Id);
            localBanco.Nome = local.Nome;
            
            if(ModelState.IsValid)
            {
                _repository.Update(localBanco);
              
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public IActionResult Delete(long id)
        {
            
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
            
            var localBanco = _repository.Get(local.Id);
            _repository.Delete(localBanco);

            return RedirectToAction("Index");
        }


    }
}