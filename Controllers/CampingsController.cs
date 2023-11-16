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
    public class CampingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campings
        public ActionResult Index()
        {
            //Getting current userID
            string currentUserId = User.Identity.GetUserId();
            //Getting campings where userId its equal to currentUserId
            var userCampings = db.Campings.Where(p => p.UserId == currentUserId).ToList();
            //Return those campings
            return View(userCampings);
        }

        // GET: Campings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camping camping = db.Campings.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ( (camping.UserId != currentUserId)  || (camping == null))
            {
                return HttpNotFound();
            }
            return View(camping);
        }

        // GET: Campings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampingId,Nombre,Descripcion,Direccion,NumeroPlazas,NumeroBungalows,HayPiscina")] Camping camping)
        {
            string currentUserId = User.Identity.GetUserId();
            camping.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Campings.Add(camping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camping);
        }

        // GET: Campings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camping camping = db.Campings.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((camping.UserId != currentUserId) || (camping == null))
            {
                return HttpNotFound();
            }
            return View(camping);
        }

        // POST: Campings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampingId,Nombre,Descripcion,Direccion,NumeroPlazas,NumeroBungalows,HayPiscina")] Camping camping)
        {
            string currentUserId = User.Identity.GetUserId();
            camping.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(camping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camping);
        }

        // GET: Campings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camping camping = db.Campings.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((camping.UserId != currentUserId) || (camping == null))
            {
                return HttpNotFound();
            }
            return View(camping);
        }

        // POST: Campings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camping camping = db.Campings.Find(id);
            db.Campings.Remove(camping);
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
