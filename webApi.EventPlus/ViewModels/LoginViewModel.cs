using System.ComponentModel.DataAnnotations;

namespace webApi.EventPlus.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
