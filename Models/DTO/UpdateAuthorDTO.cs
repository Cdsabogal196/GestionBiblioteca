using System.ComponentModel.DataAnnotations;

namespace GestionDeBiblioteca.Models.DTO
{
    public class UpdateAuthorDTO : CreateAuthorDTO
    {
        [Required] public int AuthorId { get; set; }
    }
}