using System;

namespace GestionDeBiblioteca.Exceptions
{
    public class DeleteAuthorWithBooksException : Exception
    {
        public DeleteAuthorWithBooksException(string name) : base(
            $"\"No se puede eliminar el autor {name} porque tiene libros asociados.")
        {
        }
    }
}