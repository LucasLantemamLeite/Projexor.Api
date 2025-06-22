using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projexor.Data.Context;

namespace Projexor.Controller;

[ApiController]
[Route("v1")]
[Tags("User")]
public class DeleteUserAccount() : ControllerBase
{

    [Authorize]
    [HttpDelete("user")]
    public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context)
    {
        try
        {
            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Guid claimId;
            if (!Guid.TryParse(id, out claimId))
                return BadRequest(new { Message = "Id inválido." });

            var userAccount = await context.UserAccounts.FirstOrDefaultAsync(x => x.Id == (claimId));

            if (userAccount == null)
                return BadRequest(new { Message = "Conta não encontrada." });

            context.UserAccounts.Remove(userAccount);
            await context.SaveChangesAsync();

            return Ok(new { Message = "Conta deletada com sucesso." });
        }

        catch (Exception e)
        {
            return StatusCode(500, new { Message = "Erro interno do servidor.", Error = e.InnerException?.Message ?? e.Message ?? "Erro desconhecido." });
        }
    }
}