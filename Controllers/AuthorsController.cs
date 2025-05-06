using System;
using System.Web.Mvc;
using GestionDeBiblioteca.Exceptions;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Services.Interfaces;

namespace GestionDeBiblioteca.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public AuthorsController()
        {
        }


        // GET: Authors
        public ActionResult Index()
        {
            return View(_authorService.GetAllAuthors());
        }

        public ActionResult Details(int? id)
        {
            try
            {
                var author = _authorService.GetAuthorById(id);
                return View(author);
            }
            catch (ProvidedIdNullException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", "" + ex.Message);
                return View();
            }
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,DateBirth,City,Email")] CreateAuthorDTO authorDto)
        {
            if (ModelState.IsValid)
            {
                _authorService.CreateAuthor(authorDto);

                return RedirectToAction("Index");
            }

            return View(authorDto);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {

            try
            {
                var authorDto = _authorService.GetAuthorForEdit(id.Value);
                return View(authorDto);
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorId,Name,DateBirth,City,Email")] UpdateAuthorDTO authorDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.UpdateAuthor(authorDto);
                    return RedirectToAction("Index");
                }
                catch (AuthorNotFoundException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View();
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(authorDto);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var authorDto = _authorService.GetAuthorForDelete(id);

                ViewBag.BookCount = authorDto.BookCount;
                return View(authorDto);
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", "Error al borrar el autor, detalles: " + ex.Message);
                return View();
            }
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _authorService.DeleteAuthor(id);
                return RedirectToAction("Index");
            }
            catch (AuthorNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (DeleteAuthorWithBooksException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}