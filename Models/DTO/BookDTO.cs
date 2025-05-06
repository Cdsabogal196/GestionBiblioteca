namespace GestionDeBiblioteca.Models.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int NumPage { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public AuthorDTO Author { get; set; }
    }
}