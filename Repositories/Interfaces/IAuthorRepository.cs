using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Models.Entities;

namespace GestionDeBiblioteca.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GetAllAuthors();
        Author GetAuthorById(int? id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
        Author GetAuthorByName(string authorName);

    }
}
