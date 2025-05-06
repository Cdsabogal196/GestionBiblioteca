using System;

namespace GestionDeBiblioteca.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException(string authorName)
            : base($"No se encontró el autor con el nombre {authorName}.")
        {
        }

        public AuthorNotFoundException(int? id)
            : base($"No se encontró el autor con el id {id}.")
        {
        }
    }
}