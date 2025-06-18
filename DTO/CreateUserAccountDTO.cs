using System.ComponentModel.DataAnnotations;

namespace Projexor.Controller.DTO;

public class CreateUserAccountDTO
{
    [Required(ErrorMessage = "O campo Name é obrigatório.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Password é obrigatório.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "O campo PhoneNumber é obrigatório.")]
    [Phone(ErrorMessage = "PhoneNumber inválido.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "O campo BirthDate é obrigatório.")]
    [DataType(DataType.Date, ErrorMessage = "BirthDate inválido.")]
    public DateOnly BirthDate { get; set; }
}