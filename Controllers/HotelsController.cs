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
{   [Authorize]
    public class HotelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hotels
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userHotels = db.Hotels.Where(p => p.UserId == currentUserId).ToList();
            return View(userHotels);
        }

        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((hotel.UserId != currentUserId)||(hotel == null))
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelID,Nombre,Direccion,NumeroEstrellas,Rural,Mascotas,SoloAdultos,Tematico,Descripcion,Parking,NumeroHabitaciones")] Hotel hotel)
        {
            string currentUserId = User.Identity.GetUserId();
            hotel.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((hotel.UserId != currentUserId) || (hotel == null))
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelID,Nombre,Direccion,NumeroEstrellas,Rural,Mascotas,SoloAdultos,Tematico,Descripcion,Parking,NumeroHabitaciones")] Hotel hotel)
        {
            string currentUserId = User.Identity.GetUserId();
            hotel.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((hotel.UserId != currentUserId) || (hotel == null))
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
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
