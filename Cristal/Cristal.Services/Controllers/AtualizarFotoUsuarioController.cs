using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarFotoUsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AtualizarFotoUsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPut("{guid:guid}")]
        public IActionResult Put(Guid guid, [FromBody] AtualizarfotoUsuarioPutModel model)
        {
            try
            {
                _usuarioAppService.AtualizarFotoUsuario(guid, model.FotoBase64);
                return StatusCode(200, new { message = "Foto atualizado com sucesso." });
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
