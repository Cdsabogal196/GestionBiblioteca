using System;
using System.ComponentModel.DataAnnotations;

namespace GestionDeBiblioteca.Models.DTO
{
    public class CreateAuthorDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [StringLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        public string AuthorName { get; set; }
    }
}