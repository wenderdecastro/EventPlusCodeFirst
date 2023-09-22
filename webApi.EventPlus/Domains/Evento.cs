using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace webApi.EventPlus.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key] 
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo IdTipoUsuario é obrigatorio")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey("IdTipoEvento")]
        public TiposEvento? TiposEvento { get; set; }

        [Required(ErrorMessage = "O campo IdInstituicao é obrigatorio")]
        public Guid IdInstituicao { get; set;}

        [ForeignKey("IdInstituicao")]
        public Instituicao? Instituicao { get; set; }

        [Required(ErrorMessage = "O campo DataEvento é obrigatorio")]
        [Column(TypeName = "DATE")]
        public DateTime DataEvento{ get; set; }

        [Required(ErrorMessage = "O campo NomeEvento é obrigatorio")]
        [Column(TypeName = "VARCHAR(128)")]
        public string? NomeEvento { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatorio")]
        [Column(TypeName = "VARCHAR(1024)")]
        public string? Descricao { get; set; }



    }
}
