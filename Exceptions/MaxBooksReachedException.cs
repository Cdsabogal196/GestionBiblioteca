using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDeBiblioteca.Exceptions
{
    public class MaxBooksReachedException : Exception
    {
        public MaxBooksReachedException()
            : base("No es posible registrar el libro, se alcanzó el máximo permitido.")
        {
        }

        public MaxBooksReachedException(string message)
            : base(message)
        {
        }
    }
}