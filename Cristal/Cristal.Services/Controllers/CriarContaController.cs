using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriarContaController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public CriarContaController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Post(CriarContaPostModel model)
        {
            try
            {
                var usuario = _usuarioAppService.Criarconta(model);
                return StatusCode(201, new { message = "Usuário cadastrado com sucesso.", usuario });
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
