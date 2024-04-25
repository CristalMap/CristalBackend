using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperarSenhaController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public RecuperarSenhaController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Post(RecuperarSenhaPostModel model)
        {
            try
            {
                var usuario = _usuarioAppService.RecuperarSenha(model);
                return StatusCode(200, new { message = "Recuperação de senha realizado com sucesso.", usuario });
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
