using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GestionDeBiblioteca.Exceptions;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Models.Entities;
using GestionDeBiblioteca.Repositories.Interfaces;
using GestionDeBiblioteca.Services.Interfaces;

namespace GestionDeBiblioteca.Services.Implementation
{
    public class AuthorService : IAuthorService
    {

        private IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<AuthorDTO> GetAllAuthors()
        {

            return _authorRepository.GetAllAuthors();

        }

        public AuthorDTO GetAuthorById(int? id)
        {

            if (id == null)
            {
                throw new ProvidedIdNullException();
            }

            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                throw new AuthorNotFoundException(id);
            }

            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                DateBirth = author.DateBirth,
                City = author.City,
                Email = author.Email,
                BookCount = author.Books?.Count ?? 0
            };
            
        }

        public void CreateAuthor(CreateAuthorDTO authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name,
                DateBirth = authorDto.DateBirth,
                City = authorDto.City,
                Email = authorDto.Email
            };

            _authorRepository.AddAuthor(author);

        }

        public UpdateAuthorDTO GetAuthorForEdit(int id)
        {

            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                throw new AuthorNotFoundException(id);
            }

            return new UpdateAuthorDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                DateBirth = author.DateBirth,
                City = author.City,
                Email = author.Email
            };
        }

        public void UpdateAuthor(UpdateAuthorDTO authorDto)
        {

            var author = _authorRepository.GetAuthorById(authorDto.AuthorId);
            if (author == null)
            {
                throw new AuthorNotFoundException(authorDto.AuthorId);
            }

            author.Name = authorDto.Name;
            author.DateBirth = authorDto.DateBirth;
            author.City = authorDto.City;
            author.Email = authorDto.Email;

            _authorRepository.UpdateAuthor(author);
            
        }

        public AuthorDTO GetAuthorForDelete(int id)
        {

            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                throw new AuthorNotFoundException(id);
            }

            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                DateBirth = author.DateBirth,
                City = author.City,
                Email = author.Email,
                BookCount = author.Books?.Count ?? 0
            };
        }

        public void DeleteAuthor(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                throw new AuthorNotFoundException(id);
            }

            if (author.Books?.Any() == true)
            {
                throw new DeleteAuthorWithBooksException(author.Name);
            }

            _authorRepository.DeleteAuthor(author);
        }
    }
}