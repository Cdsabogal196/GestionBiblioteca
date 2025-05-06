using System.Collections.Generic;
using System.Web.Mvc;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Models.Entities;

namespace GestionDeBiblioteca.Services.Interfaces
{
    public interface IBookService
    {
        List<BookDTO> GetAllBooks();
        BookDTO GetBookById(int? id);
        void CreateBook(CreateBookDTO bookDTO);
        void UpdateBook(UpdateBookDTO bookDTO);
        void DeleteBook(int? id);
    }
}