using System.ComponentModel.DataAnnotations;

namespace Projexor.Controller.DTO;

public class UpdateUserAccountDTO
{
    public string? Name { get; set; }
    public string? NewPassword { get; set; }

    [Required(ErrorMessage = "O campo de PasswordConfirm é obrigatório.")]
    public string PasswordConfirm { get; set; } = null!;
}