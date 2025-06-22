using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projexor.Controller.DTO;
using Projexor.Data.Context;
using Projexor.Services.Authentication;

namespace Projexor.Controller;


[ApiController]
[Route("v1")]
[Tags("User")]
public class UpdateUserAccount : ControllerBase
{
    [Authorize]
    [HttpPut("user")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserAccountDTO user_dto, [FromServices] AppDbContext context)
    {
        try
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Guid id;
            if (!Guid.TryParse(userId, out id))
                return BadRequest(new { Message = "Id inválido." });

            var userAccount = await context.UserAccounts.FirstOrDefaultAsync(x => x.Id == id);

            if (userAccount == null)
                return NotFound(new { Message = "Conta não encontrada." });

            if (!userAccount.PasswordHash.VerifyHash(user_dto.PasswordConfirm))
                return BadRequest(new { Message = "Senha incorreta." });

            if (user_dto.Name != null && !string.IsNullOrWhiteSpace(user_dto.Name))
                userAccount.Name = user_dto.Name;


            if (user_dto.NewPassword != null && !string.IsNullOrWhiteSpace(user_dto.NewPassword))
                userAccount.PasswordHash = user_dto.NewPassword.GenerateHash();

            await context.SaveChangesAsync();

            return Ok(new { Message = "Dados alterados com sucesso." });
        }

        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno do servidor.", Error = e.InnerException?.Message ?? e.Message ?? "Erro desconhecido." });
        }
    }
}