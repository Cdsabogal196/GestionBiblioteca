using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDeBiblioteca.Exceptions
{
    public class ProvidedIdNullException : Exception
    {
        public ProvidedIdNullException() : base($"El id proporcionado del objeto es nulo.")
        {
        }
    }
}