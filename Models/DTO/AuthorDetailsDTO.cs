using System;
using System.Collections.Generic;

namespace GestionDeBiblioteca.Models.DTO
{
    public class AuthorDetailsDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}