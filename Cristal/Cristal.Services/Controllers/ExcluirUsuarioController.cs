using Cristal.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExcluirUsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public ExcluirUsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpDelete("{guid:guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                _usuarioAppService.ExcluirUsuario(guid);
                return StatusCode(204, new { message = "Usuário excluído com sucesso." });
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
