using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Models;

namespace ASPNETArvestus.Controllers
{
    public class BookingsController : Controller
    {
        private DataBaseContext _db = new DataBaseContext();
        private readonly IEFRepository<Booking> _repo;
        private readonly IEFRepository<Client> _repoClients;
        private readonly IEFRepository<Lift> _repoLifts;

        public BookingsController()
        {
            _repo = new EFRepository<Booking>(_db);
            _repoClients = new EFRepository<Client>(_db);
            _repoLifts = new EFRepository<Lift>(_db);
        }

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = _repo.All;
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _repo.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_repoClients.All, "ClientId", "FirstName");
            ViewBag.LiftId = new SelectList(_repoLifts.All, "LiftId", "LiftNumber");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,ClientId,LiftId,Start,Finish,Notes")] Booking booking, string txbStartTime, string txbEndTime)
        {
            if (ModelState.IsValid)
            {
                DateTime start, end;
                DateTime.TryParse(txbStartTime, out start);
                DateTime.TryParse(txbEndTime, out end);
                booking.Start = start;
                booking.Finish = end;
                _repo.Add(booking);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_repoClients.All, "ClientId", "FirstName", booking.ClientId);
            ViewBag.LiftId = new SelectList(_repoLifts.All, "LiftId", "LiftNumber", booking.LiftId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _repo.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(_repoClients.All, "ClientId", "FirstName", booking.ClientId);
            ViewBag.LiftId = new SelectList(_repoLifts.All, "LiftId", "LiftNumber", booking.LiftId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,ClientId,LiftId,Start,Finish,Notes")] Booking booking, string txbStartTime, string txbEndTime)
        {
            if (ModelState.IsValid)
            {
                DateTime start, end;
                DateTime.TryParse(txbStartTime, out start);
                DateTime.TryParse(txbEndTime, out end);
                booking.Start = start;
                booking.Finish = end;
                _repo.Update(booking);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(_repoClients.All, "ClientId", "FirstName", booking.ClientId);
            ViewBag.LiftId = new SelectList(_repoLifts.All, "LiftId", "LiftNumber", booking.LiftId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _repo.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _repo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
