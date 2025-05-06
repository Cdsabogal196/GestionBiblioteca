using System;

namespace GestionDeBiblioteca.Models.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public int BookCount { get; set; }
    }
}