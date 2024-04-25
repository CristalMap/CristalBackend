using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarUsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AtualizarUsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPut("{guid:guid}")]
        public IActionResult Put(Guid guid, [FromBody] AtualizarUsuarioPutModel model)
        {
            try
            {
                var usuario = _usuarioAppService.AtualizarUsuario(guid, model);
                return StatusCode(200, new { message = "Usuário atualizado com sucesso.", usuario });
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
