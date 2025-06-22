using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projexor.Controller.DTO;
using Projexor.Data.Context;
using Projexor.Models;
using Projexor.Services.Authentication;
using Projexor.Services.Token;

namespace Projexor.Controller;

[ApiController]
[Route("v1")]
[Tags("User")]
public class CreateUserAccount : ControllerBase
{
    [HttpPost("user")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserAccountDTO user_dto, [FromServices] AppDbContext context)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userAccount = new UserAccount(user_dto.Name, user_dto.Email, user_dto.Password.GenerateHash(), user_dto.PhoneNumber, user_dto.BirthDate);

            await context.UserAccounts.AddAsync(userAccount);
            await context.SaveChangesAsync();

            return StatusCode(200, new { Message = "Conta criada com sucesso.", TokenKey = JwtServices.GenerateToken(userAccount), Error = "[]" });
        }

        catch (DbUpdateException e)
        {
            string? msg = null;

            if (e != null)
            {
                if (e.InnerException.Message.Contains("UserAccount.Email"))
                    msg = "Email já existe";

                else if (e.InnerException.Message.Contains("UserAccount.PhoneNumber"))
                    msg = "PhoneNumber já existe";
            }

            return BadRequest(new { Message = "Erro ao adicionar conta do usuário", Error = msg ?? e.InnerException?.Message ?? e.Message ?? "Erro desconhecido." });
        }

        catch (Exception e)
        {


            return StatusCode(500, new { Message = "Erro interno do servidor.", Error = e.InnerException?.Message ?? e.Message ?? "Erro desconhecido." });
        }
    }
}