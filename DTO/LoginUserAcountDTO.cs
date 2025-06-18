using System.ComponentModel.DataAnnotations;

namespace Projexor.Controller.DTO;

public class LoginUserAccountDTO
{

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Password é obrigatório.")]
    public string Password { get; set; }
}