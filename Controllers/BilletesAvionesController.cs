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
    public class BilletesAvionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BilletesAviones
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userBilletesAvion = db.BilleteAvions.Where(p => p.UserId == currentUserId).ToList();
            return View(userBilletesAvion);
        }

        // GET: BilletesAviones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilleteAvion billeteAvion = db.BilleteAvions.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((billeteAvion.UserId != currentUserId) || (billeteAvion == null))
            {
                return HttpNotFound();
            }
            return View(billeteAvion);
        }

        // GET: BilletesAviones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BilletesAviones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBilleteAvion,CompaniaAerea,AeropuertoOrigen,AeropuertoDestino,LowCost,NumeroPlazas,Fecha,HoraSalida,HoraLlegada")] BilleteAvion billeteAvion)
        {
            string currentUserId = User.Identity.GetUserId();
            billeteAvion.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.BilleteAvions.Add(billeteAvion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billeteAvion);
        }

        // GET: BilletesAviones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilleteAvion billeteAvion = db.BilleteAvions.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((billeteAvion.UserId != currentUserId) || (billeteAvion == null))
            {
                return HttpNotFound();
            }
            return View(billeteAvion);
        }

        // POST: BilletesAviones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBilleteAvion,CompaniaAerea,AeropuertoOrigen,AeropuertoDestino,LowCost,NumeroPlazas,Fecha,HoraSalida,HoraLlegada")] BilleteAvion billeteAvion)
        {
            string currentUserId = User.Identity.GetUserId();
            billeteAvion.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(billeteAvion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billeteAvion);
        }

        // GET: BilletesAviones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilleteAvion billeteAvion = db.BilleteAvions.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((billeteAvion.UserId != currentUserId) || (billeteAvion == null))
            {
                return HttpNotFound();
            }
            return View(billeteAvion);
        }

        // POST: BilletesAviones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BilleteAvion billeteAvion = db.BilleteAvions.Find(id);
            db.BilleteAvions.Remove(billeteAvion);
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
