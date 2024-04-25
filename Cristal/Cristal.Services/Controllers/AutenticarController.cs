using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Cristal.Services.Configurations.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly JwtTokenCreator _jwtTokenCreator;
        private readonly IUsuarioAppService _usuarioAppService;

        public AutenticarController(JwtTokenCreator jwtTokenCreator, IUsuarioAppService usuarioAppService)
        {
            _jwtTokenCreator = jwtTokenCreator;
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Post(AutenticarPostModel model)
        {
            try
            {
                var usuario = _usuarioAppService.Autenticar(model);
                return StatusCode(200, new
                {
                    message = "Usuário autenticado com sucesso.",
                    usuario,
                    token = _jwtTokenCreator.GenerateToken(usuario.Email)
                });
            }
            catch (ArgumentException ex)
            {
                return StatusCode(401, new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
