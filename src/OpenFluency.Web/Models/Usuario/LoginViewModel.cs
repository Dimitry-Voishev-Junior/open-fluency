using System.ComponentModel.DataAnnotations;

namespace OpenFluency.Web.Models.Usuario
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Usuario é obrigatório.")]
        public string? Usuario { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string? Senha { get; set; }

        public bool LembrarMe { get; set; }
    }
}
