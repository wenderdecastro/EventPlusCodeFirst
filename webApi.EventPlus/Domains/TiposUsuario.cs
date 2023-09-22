using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApi.EventPlus.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(64)")]
        [Required(ErrorMessage = "O Nome do tipo do usuario é obrigatório")]
        public string? NomeTipoUsuario { get; set; }
    }
}
