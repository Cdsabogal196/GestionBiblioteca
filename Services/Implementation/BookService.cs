using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GestionDeBiblioteca.Exceptions;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Models.Entities;
using GestionDeBiblioteca.Repositories.Interfaces;
using GestionDeBiblioteca.Services.Interfaces;

namespace GestionDeBiblioteca.Services.Implementation
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        private IAuthorRepository authorRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }

        public List<BookDTO> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookDTO GetBookById(int? id)
        {
            if (id == null)
            {
                throw new ProvidedIdNullException();
            }

            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                throw new BookNotFoundException(id.Value);
            }

            return new BookDTO
            {
                BookId = book.BookId,
                Title = book.Title,
                Year = book.Year,
                Genre = book.Genre,
                NumPage = book.NumPage,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.Name
            };
        }

        public void CreateBook(CreateBookDTO bookDTO)
        {
            int currentBookCount = _bookRepository.GetCountBooks();

            if (currentBookCount >= 10)
            {
                throw new MaxBooksReachedException();
            }

            var author = FindAuthorByName(bookDTO.AuthorName);

            if (author == null)
            {
                throw new AuthorNotFoundException(bookDTO.AuthorName);
            }

            var book = new Book()
            {
                Title = bookDTO.Title,
                Year = bookDTO.Year,
                Genre = bookDTO.Genre,
                NumPage = bookDTO.NumPage,
                AuthorId = author.AuthorId
            };

            _bookRepository.AddBook(book);
        }

        private Author FindAuthorByName(string authorName)
        {
           
            return authorRepository.GetAuthorByName(authorName);
        }

        public void UpdateBook(UpdateBookDTO bookDTO)
        {
            var author = FindAuthorByName(bookDTO.AuthorName);
            var existingBook = _bookRepository.GetBookById(bookDTO.BookId);

            if (existingBook == null)
            {
                throw new BookNotFoundException(bookDTO.BookId);
            }

            if (author == null)
            {
                throw new AuthorNotFoundException(bookDTO.AuthorName);
            }

            existingBook.Title = bookDTO.Title;
            existingBook.Year = bookDTO.Year;
            existingBook.Genre = bookDTO.Genre;
            existingBook.NumPage = bookDTO.NumPage;
            existingBook.AuthorId = author.AuthorId;

            _bookRepository.UpdateBook(existingBook);
        }

        public void DeleteBook(int? id)
        {
            if (id == null)
            {
                throw new ProvidedIdNullException();
            }

            var book = _bookRepository.GetBookById(id);
            if (book != null)
            {
                _bookRepository.DeleteBook(book);
            }
        }
    }
}