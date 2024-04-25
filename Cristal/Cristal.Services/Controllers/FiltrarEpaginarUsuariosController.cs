using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrarEpaginarUsuariosController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public FiltrarEpaginarUsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ListarUsuarioGetModel model)
        {
            try
            {
                var usuarios = _usuarioAppService.FiltrarEpaginarUsuarios(model);
                return StatusCode(200, new { message = "Usuários listados com sucesso.", usuarios });
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
