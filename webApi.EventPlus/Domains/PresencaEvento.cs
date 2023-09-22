using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApi.EventPlus.Domains
{
    public class PresencaEvento
    {
        [Key]
        public Guid IdPresenca { get; set; } = Guid.NewGuid(); 

        [Required(ErrorMessage = "O campo IdEvento é obrigatorio")]
        public Guid IdEvento { get; set; }

        
        [ForeignKey("IdEvento")]
        public Evento? Evento { get; set; }

        [Required(ErrorMessage = "O campo IdUsuario é obrigatorio")]
        public Guid IdUsuario { get; set; }

        
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario{ get; set; }

        [Required(ErrorMessage = "O campo Situacao é obrigatorio")]
        public bool Situacao { get; set; }



    }
}
