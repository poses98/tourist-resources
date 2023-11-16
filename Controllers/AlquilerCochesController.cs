using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcoTravel.Models;
using Microsoft.AspNet.Identity;

namespace EcoTravel.Controllers
{
    [Authorize]
    public class AlquilerCochesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AlquilerCoches
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userAlquilerCoches = db.AlquilerCoches.Where(p => p.UserId == currentUserId).ToList();
            return View(userAlquilerCoches);
        }

        // GET: AlquilerCoches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlquilerCoche alquilerCoche = db.AlquilerCoches.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((alquilerCoche.UserId != currentUserId) || (alquilerCoche == null))
            {
                return HttpNotFound();
            }
            return View(alquilerCoche);
        }

        // GET: AlquilerCoches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlquilerCoches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,compañia_Alquiler,direccion_Recogida,tipo_Coche,num_Plazas,num_Coches,ofrece_Seguro,ofrece_Sillas")] AlquilerCoche alquilerCoche)
        {
            string currentUserId = User.Identity.GetUserId();
            alquilerCoche.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.AlquilerCoches.Add(alquilerCoche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alquilerCoche);
        }

        // GET: AlquilerCoches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlquilerCoche alquilerCoche = db.AlquilerCoches.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((alquilerCoche.UserId != currentUserId) || (alquilerCoche == null))
            {
                return HttpNotFound();
            }
            return View(alquilerCoche);
        }

        // POST: AlquilerCoches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,compañia_Alquiler,direccion_Recogida,tipo_Coche,num_Plazas,num_Coches,ofrece_Seguro,ofrece_Sillas")] AlquilerCoche alquilerCoche)
        {
            string currentUserId = User.Identity.GetUserId();
            alquilerCoche.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(alquilerCoche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alquilerCoche);
        }

        // GET: AlquilerCoches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlquilerCoche alquilerCoche = db.AlquilerCoches.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((alquilerCoche.UserId != currentUserId) || (alquilerCoche == null))
            {
                return HttpNotFound();
            }
            return View(alquilerCoche);
        }

        // POST: AlquilerCoches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AlquilerCoche alquilerCoche = db.AlquilerCoches.Find(id);
            db.AlquilerCoches.Remove(alquilerCoche);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
