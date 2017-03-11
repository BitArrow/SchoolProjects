using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNETArvestus.ViewModels;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Models;

namespace ASPNETArvestus.Controllers
{
    public class LiftsController : Controller
    {
        private DataBaseContext _db = new DataBaseContext();
        private readonly IEFRepository<Lift> _repo;
        private readonly IEFRepository<Booking> _repoBooking;

        public LiftsController()
        {
            _repo = new EFRepository<Lift>(_db);
            _repoBooking = new EFRepository<Booking>(_db);
        }

        // GET: Lifts
        public ActionResult Index()
        {
            return View(_repo.All);
        }

        // GET: Lifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int _id = (int)id;

            var vm = new LiftViewModel
            {
                Lift = _repo.GetById(id),
                Bookings = _repoBooking.All.Where(x => x.LiftId == _id).OrderBy(d => d.Start)
            };

            Lift lift = _repo.GetById(id);
            if (lift == null)
            {
                return HttpNotFound();
            }

            return View(vm);
        }

        // GET: Lifts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LiftId,LiftNumber,Name,MaxWeight")] Lift lift)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(lift);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lift);
        }

        // GET: Lifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lift lift = _repo.GetById(id);
            if (lift == null)
            {
                return HttpNotFound();
            }
            return View(lift);
        }

        // POST: Lifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LiftId,LiftNumber,Name,MaxWeight")] Lift lift)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(lift);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lift);
        }

        // GET: Lifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lift lift = _repo.GetById(id);
            if (lift == null)
            {
                return HttpNotFound();
            }
            return View(lift);
        }

        // POST: Lifts/Delete/5
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
