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
    public class ClientsController : Controller
    {
        private DataBaseContext _db = new DataBaseContext();
        private readonly IEFRepository<Client> _repo;
        private readonly IEFRepository<ClientType> _repoCType;


        public ClientsController()
        {
            _repo = new EFRepository<Client>(_db);
            _repoCType = new EFRepository<ClientType>(_db);
        }

        // GET: Clients
        //public ActionResult Index()
        //{
        //    var clients =_repo.All;
        //    return View(clients);
        //}

        public ActionResult Index(string txbFirstName)
        {
            var clients = _repo.All;

            if (!string.IsNullOrEmpty(txbFirstName))
            {
                txbFirstName = txbFirstName.ToUpper();
                clients = clients.Where(s => s.FirstName.ToUpper().Contains(txbFirstName)
                                             || s.LastName.ToUpper().Contains(txbFirstName)).ToList();
            }

            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _repo.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            var vm = new ClientViewModel
            {
                Client = new Client(),
                ClientTypes = _repoCType.All
            };
            ViewBag.ClientTypeId = new SelectList(_repoCType.All, "ClientTypeId", "TypeName");
            return View(vm);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,ClientTypeId,FirstName,LastName")] Client client)
        {
            var vm = new ClientViewModel
            {
                Client = client,
                ClientTypes = _repoCType.All
            };
            if (ModelState.IsValid)
            {
                _repo.Add(client);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientTypeId = new SelectList(_repoCType.All, "ClientTypeId", "TypeName", client.ClientTypeId);
            return View(vm);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new ClientViewModel
            {
                Client = _repo.GetById(id),
                ClientTypes = _repoCType.All
            };
            Client client = _repo.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientTypeId = new SelectList(_repoCType.All, "ClientTypeId", "TypeName", client.ClientTypeId);
            return View(vm);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,ClientTypeId,FirstName,LastName")] Client client)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(client);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            var vm = new ClientViewModel
            {
                Client = client,
                ClientTypes = _repoCType.All
            };
            ViewBag.ClientTypeId = new SelectList(_repoCType.All, "ClientTypeId", "TypeName", client.ClientTypeId);
            return View(vm);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _repo.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
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
