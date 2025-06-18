using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projexor.Controller.DTO;
using Projexor.Data.Context;
using Projexor.Services.Authentication;
using Projexor.Services.Token;

namespace Projexor.Controller;

[ApiController]
[Route("v1")]
public class LoginUserAccount : ControllerBase
{
    [HttpPost("login-user")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserAccountDTO user_dto, [FromServices] AppDbContext context)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userAccount = await context.UserAccounts.FirstOrDefaultAsync(x => x.Email == user_dto.Email);

            if (userAccount == null)
                return NotFound(new { Message = "Conta não encontrada" });

            if (!userAccount.PasswordHash.VerifyHash(user_dto.Password))
                return BadRequest(new { Message = "Email ou senha incorretos." });

            return Ok(new { Message = "Login bem sucedido", TokenKey = JwtServices.GenerateToken(userAccount), Error = "[]" });
        }

        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno do servidor.", Error = e.InnerException?.Message ?? e.Message ?? "Erro desconhecido." });
        }
    }
}