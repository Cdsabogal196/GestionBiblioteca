using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDeBiblioteca.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(int id)
            : base($"No se encontró el libro con ID {id}.")
        {
        }
    }
}