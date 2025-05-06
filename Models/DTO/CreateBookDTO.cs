using System.ComponentModel.DataAnnotations;

namespace GestionDeBiblioteca.Models.DTO
{
    public class CreateBookDTO
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "Año inválido")]
        public int Year { get; set; }

        [Required][StringLength(50)] public string Genre { get; set; }

        [Required]
        [Display(Name = "Número de Páginas")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser positivo")]
        public int NumPage { get; set; }

        [Required] public string AuthorName { get; set; }
    }
}