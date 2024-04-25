using Cristal.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ListarDenunciaEstatisticaController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public ListarDenunciaEstatisticaController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpGet("{guid:guid}")]
        public IActionResult Get(Guid guid)
        {
            try
            {
                var estatisticaDenuncas = _denunciaAppService.ListarDenunciaEstatistica(guid);
                return StatusCode(200, new { message = "Estatistica denuncia listado com sucesso.", estatisticaDenuncas });
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
