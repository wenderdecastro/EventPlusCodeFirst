using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.EventPlus.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CPNJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo CNPJ é obrigatorio")]
        [Column(TypeName = "VARCHAR(14)")]
        public string? CPNJ { get; set; }

        [Required(ErrorMessage = "O campo Endereco é obrigatorio")]
        [Column(TypeName = "VARCHAR(128)")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "O campo NomeFantasia é obrigatorio")]
        [Column(TypeName = "VARCHAR(128)")]
        public string? NomeFantasia { get; set; }
    }
}
