using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Models.Entities;
using GestionDeBiblioteca.Repositories.Interfaces;

namespace GestionDeBiblioteca.Repositories.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private AppDbContext _db = new AppDbContext();

        public AuthorRepository(AppDbContext context)
        {
            _db = context;
        }
        public void AddAuthor(Author author)
        {
            _db.Author.Add(author);
            _db.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {

            _db.Author.Remove(author);
            _db.SaveChanges();
        }

        public List<AuthorDTO> GetAllAuthors()
        {
            var authorDtos = _db.Author
                            .Include(a => a.Books)
                            .Select(a => new AuthorDTO
                            {
                              AuthorId = a.AuthorId,
                              Name = a.Name,
                              DateBirth = a.DateBirth,
                              City = a.City,
                              Email = a.Email,
                              BookCount = a.Books.Count
                          })
                          .ToList();

            return authorDtos;
        }

        public Author GetAuthorById(int? id)
        {
           return _db.Author.Find(id);

        }

        public void UpdateAuthor(Author author)
        {

            _db.Entry(author).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Author GetAuthorByName(string authorName)
        {
            var author = _db.Author
                .FirstOrDefault(a => a.Name.ToLower() == authorName.ToLower());
            return author;
        }

    }
}