using System;
using System.Web.Mvc;
using GestionDeBiblioteca.Exceptions;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Services.Implementation;

namespace GestionDeBiblioteca.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                var book = _bookService.GetBookById(id);
                return View(book);
            }


            catch (ProvidedIdNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (BookNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,Year,Genre,NumPage,AuthorName")] CreateBookDTO book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookService.CreateBook(book);
                    return RedirectToAction("Index");
                }
            }

            catch (MaxBooksReachedException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", "Datos inválidos: " + ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ProvidedIdNullException();
                }

                var book = _bookService.GetBookById(id.Value);
                if (book == null)
                {
                    throw new BookNotFoundException(id.Value);
                }

                var updateBookDTO = new UpdateBookDTO()
                {
                    BookId = book.BookId,
                    Genre = book.Genre,
                    NumPage = book.NumPage,
                    Title = book.Title,
                    Year = book.Year,
                    AuthorName = book.AuthorName
                };

                return View(updateBookDTO);
            }
            catch (ProvidedIdNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
            catch (BookNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An unexpected error occurred");
                return RedirectToAction("Index");
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,Year,Genre,NumPage,AuthorName")] UpdateBookDTO book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookService.UpdateBook(book);
                    return RedirectToAction("Index");
                }

                //ViewBag.AuthorId = _bookService.GetAuthorsSelectList(book.AuthorId);
                return View(book);
            }
            catch (BookNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(book);
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(book);
            }
        }


        // GET: Books/Delete/5
        // Add these methods to your existing BooksController
        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                var book = _bookService.GetBookById(id);

                return View(book);
            }
            catch (BookNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (ProvidedIdNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}