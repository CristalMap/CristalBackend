using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrarEpaginarUsuariosQuantidadeController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public FiltrarEpaginarUsuariosQuantidadeController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ListarUsuarioGetModel model)
        {
            try
            {
                var quantidade = _usuarioAppService.FiltrarEpaginarUsuariosQuantidade(model);
                return StatusCode(200, new { message = "Quantidade de usuários listados com sucesso.", quantidade });
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
