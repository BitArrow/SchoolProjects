using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNetArvestus02.ViewModels;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace ASPNetArvestus02.Controllers
{
    public class BooksController : Controller
    {
        private readonly DataBaseContext _db = new DataBaseContext();

        private readonly IEFRepository<Book> _repo;
        private readonly IEFRepository<Publisher> _repoPublishers;
        private readonly IEFRepository<Author> _repoAuthors;
        private readonly IEFRepository<AuthorBook> _repoAuthorBooks;

        public BooksController()
        {
            _repo = new EFRepository<Book>(_db);
            _repoPublishers = new EFRepository<Publisher>(_db);
            _repoAuthors = new EFRepository<Author>(_db);
            _repoAuthorBooks = new EFRepository<AuthorBook>(_db);
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _repo.All;
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repo.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            var vm = new BookCreateEditViewModel()
            {
                PublisherSelectList = new SelectList(_repoPublishers.All, "PublisherId", "PublisherName"),
                AuthorMultiSelectList = new MultiSelectList(_repoAuthors.All, nameof(Author.AuthorId), nameof(Author.FirstLastname))
            };

            return View(vm);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                foreach (var authorId in vm.AuthorIds)
                {
                    vm.Book.BookAuthors.Add(new AuthorBook() { AuthorId = authorId });
                }
                _repo.Add(vm.Book);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.PublisherSelectList = new SelectList(_repoPublishers.All, "PublisherId", "PublisherName", vm.Book.PublisherId);
            return View(vm);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repo.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var vm = new BookCreateEditViewModel()
            {
                Book = book,
                PublisherSelectList = new SelectList(_repoPublishers.All, "PublisherId", "PublisherName", book.PublisherId),
                AuthorMultiSelectList = new MultiSelectList(_repoAuthors.All, nameof(Author.AuthorId), nameof(Author.FirstLastname), _repoAuthorBooks.All.Where(a => a.BookId == book.BookId).Select(b => b.AuthorId).ToArray())
            };
            return View(vm);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //var book = _repo.GetById(vm.Book.BookId);
                //book.BookAuthors.Clear();
                //_repo.SaveChanges();

                foreach (var authorBook in _repoAuthorBooks.All.Where(a => a.BookId == vm.Book.BookId))
                {
                    _repoAuthorBooks.Delete(authorBook);
                }

                _repo.Update(vm.Book);
                _repo.SaveChanges();


                foreach (var authorId in vm.AuthorIds)
                {
                    vm.Book.BookAuthors.Add(new AuthorBook() { AuthorId = authorId, AuthorBookId = vm.Book.BookId });
                }

                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.PublisherSelectList = new SelectList(_repoPublishers.All, "PublisherId", "PublisherName",
                vm.Book.PublisherId);
            vm.AuthorMultiSelectList = new MultiSelectList(_repoAuthors.All, nameof(Author.AuthorId),
                nameof(Author.FirstLastname), vm.AuthorIds);

            return View(vm);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repo.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
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
