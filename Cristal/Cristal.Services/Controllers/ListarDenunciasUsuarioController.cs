using Cristal.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ListarDenunciasUsuarioController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public ListarDenunciasUsuarioController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpGet("{guid:guid}")]
        public IActionResult Get(Guid guid)
        {
            try
            {
                var denuncias = _denunciaAppService.ListarDenunciasUsuario(guid);
                return StatusCode(200, new { message = "Denúncias do usuário listadas com sucesso.", denuncias });
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
