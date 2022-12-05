using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PubsMVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PubsMVCCore.Controllers
{
    public class StoreController : Controller
    {
        private readonly PubsContext _context;

        public StoreController(PubsContext context)
        {
            _context = context;
        }

        // GET: /store
        public ActionResult Index()
        {
            return View("Index", _context.Stores.ToList());
        }

        //GET: /store/create

        public ActionResult Create()
        {
            Store store = new Store();
            return View("Create", store);
        }

        //POST: /store/create
        [HttpPost]

        public ActionResult Create(Store store)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", store);
            }
            else
            {
                _context.Stores.Add(store);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: /store/detalle/id

        [HttpGet]
        [ActionName("Detalle")]

        public ActionResult Detalle(int id)
        {
            Store store = _context.Stores.Find(id);

            if (store != null)
            {
                return View("Detalle", store);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/store/ListarPorCiudad/{Ciudad}")]

        public ActionResult ListarPorCiudad(string ciudad)
        {
            List<Store> stores = (from s in _context.Stores
                                  where s.City == ciudad
                                  select s).ToList();

            return View("Index", stores);
        }

        //GET: store/delete/id

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Store store = _context.Stores.Find(id);

            if (store == null)
            {
                return NotFound();

            }
            return View("Delete", store);
        }

        [HttpPost]
        [ActionName("Delete")]

        //POST: /store/DeleteConfirmed/id

        public ActionResult DeleteConfirmed(int id)
        {
            Store store = _context.Stores.Find(id);

            if (store != null)
            {
                _context.Stores.Remove(store);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("/store/Modificar/{StoreId}")]

        public ActionResult Modificar(int id)
        {
            Store store = _context.Stores.Find(id);

            if (store == null)
            {
                return NotFound();
            }
            else
            {
                return View("Modificar", store);
            }
        }

        [HttpPost]

        public ActionResult Modificar(Store store)
        {
            if (!ModelState.IsValid)
            {
                return View("Modificar", store);
            }
            else
            {
                _context.Entry(store).State = EntityState.Modified;
                _context.SaveChanges();
                return View("Index", store);
            }
        }
    }
}
