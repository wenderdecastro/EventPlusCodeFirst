using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.EventPlus.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O tipo do usuario é obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TiposUsuario { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [Column(TypeName = "VARCHAR(64)")]
        [StringLength(64, MinimumLength = 8)]
        public string? Senha { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O Nome de usuario é obrigatorio")]
        [Column(TypeName = "VARCHAR(64)")]
        public string? NomeUsuario { get; set; }

    }
}
