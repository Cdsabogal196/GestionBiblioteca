using System.Collections.Generic;
using GestionDeBiblioteca.Models.DTO;

namespace GestionDeBiblioteca.Services.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorDTO> GetAllAuthors();
        AuthorDTO GetAuthorById(int? id);
        void CreateAuthor(CreateAuthorDTO authorDto);
        void UpdateAuthor(UpdateAuthorDTO authorDto);
        UpdateAuthorDTO GetAuthorForEdit(int id);
        AuthorDTO GetAuthorForDelete(int id);
        void DeleteAuthor(int id);
    }
}