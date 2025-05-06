using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeBiblioteca.Models.DTO;
using GestionDeBiblioteca.Models.Entities;

namespace GestionDeBiblioteca.Repositories.Interfaces
{
    public interface IBookRepository
    {

        List<BookDTO> GetAllBooks();
        Book GetBookById(int? id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        int GetCountBooks();
    }
}
