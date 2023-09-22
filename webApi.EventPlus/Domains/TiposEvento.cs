using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.EventPlus.Domains
{
    [Table("TiposEvento")]
    public class TiposEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(64)")]
        [Required(ErrorMessage = "O Nome do tipo do evento é obrigatório")]
        public string? NomeTipoEvento { get; set; }


    }
}
