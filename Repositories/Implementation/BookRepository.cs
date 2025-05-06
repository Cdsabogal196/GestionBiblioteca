using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Models.Entities;
using GestionDeBiblioteca.Repositories.Interfaces;

namespace GestionDeBiblioteca.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _db = new AppDbContext();

        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public void AddBook(Book book)
        {
            _db.Book.Add(book);
            _db.SaveChanges();

        }

        public void DeleteBook(Book book)
        {
            _db.Book.Remove(book);
            _db.SaveChanges();
        }

        public List<BookDTO> GetAllBooks()
        {
            var books = _db.Book
                           .Include(b => b.Author)
                           .Select(b => new BookDTO
                           {
                               BookId = b.BookId,
                               Title = b.Title,
                               Year = b.Year,
                               Genre = b.Genre,
                               NumPage = b.NumPage,
                               AuthorId = b.AuthorId,
                               AuthorName = b.Author.Name
                           })
                           .ToList();

            return books;
        }

        public Book GetBookById(int? id)
        {
           return _db.Book.Find(id);
        }

        public int GetCountBooks()
        {
            return _db.Book.Count();
        }

        public void UpdateBook(Book book)
        {

            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}