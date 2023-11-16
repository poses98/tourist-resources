using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcoTravel.Models;

namespace EcoTravel.Controllers
{
    [Authorize]
    public class IncidenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Incidencias
        public ActionResult Index()
        {
            return View(db.Incidencias.ToList());
        }

        // GET: Incidencias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencia incidencia = db.Incidencias.Find(id);
            if (incidencia == null)
            {
                return HttpNotFound();
            }
            return View(incidencia);
        }

        // GET: Incidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Incidencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipoRecurso,nombre_Compania,descripcion,grevedad,opinion")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                db.Incidencias.Add(incidencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incidencia);
        }

        // GET: Incidencias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencia incidencia = db.Incidencias.Find(id);
            if (incidencia == null)
            {
                return HttpNotFound();
            }
            return View(incidencia);
        }

        // POST: Incidencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipoRecurso,nombre_Compania,descripcion,grevedad,opinion")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incidencia);
        }

        // GET: Incidencias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incidencia incidencia = db.Incidencias.Find(id);
            if (incidencia == null)
            {
                return HttpNotFound();
            }
            return View(incidencia);
        }

        // POST: Incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Incidencia incidencia = db.Incidencias.Find(id);
            db.Incidencias.Remove(incidencia);
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
