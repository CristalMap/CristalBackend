using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarSenhaController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AtualizarSenhaController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPut("{guid:guid}")]
        public IActionResult Put(Guid guid, [FromBody] AtualizarSenhaPutModel model)
        {
            try
            {
                _usuarioAppService.AtualizarSenha(guid, model);
                return StatusCode(200, new { message = "Senha atualizada com sucesso." });
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
