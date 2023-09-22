using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.EventPlus.Domains
{
    [Table("ComentariosEvento")]
    public class ComentariosEvento
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo IdEvento é obrigatorio")]
        public Guid IdEvento { get; set; }

        [Required(ErrorMessage = "O campo IdUsuario é obrigatorio")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatorio")]
        [Column(TypeName = "TEXT")]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool exibir { get; set; } = false;

        [ForeignKey("IdEvento")]
        public Evento? evento { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? usuario { get; set; }

    }
}
