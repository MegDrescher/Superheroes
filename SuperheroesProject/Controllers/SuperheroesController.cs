using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SuperheroesProject.Models;

namespace SuperheroesProject.Controllers
{
    public class SuperheroesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Superheroes

        public List<Superhero> GetSuperheroes()
        {
            var superheroes = db.Superheroes.Select(x => x).ToList();
            return superheroes;
        }

        public ActionResult Index()
        {
            var s = GetSuperheroes();
            return View(s);
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            var s = db.Superheroes.Where(x => x.ID == id).Select(x => x).FirstOrDefault();
            return View();
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        // POST: Superheroes/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                db.Superheroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }         
        }
          // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(db.Superheroes.Find(id));
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Superhero superhero)
        {
            try
            {
                // TODO: Add update logic
                Superhero superheroFromDb = db.Superheroes.Where(x => x.ID == id).Select(x => x).FirstOrDefault();
                superheroFromDb.Name = superhero.Name;
                superheroFromDb.AlterEgoName = superhero.AlterEgoName;
                superheroFromDb.PrimaryAbility = superhero.PrimaryAbility;
                superheroFromDb.SecondaryAbility = superhero.SecondaryAbility;
                superheroFromDb.CatchPhrase = superhero.CatchPhrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(db.Superheroes.Find(id));
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Superhero superheroToDelete = db.Superheroes.Find(id);
                db.Superheroes.Remove(superheroToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
                
        }
    }
}

