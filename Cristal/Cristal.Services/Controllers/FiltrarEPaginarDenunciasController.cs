using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrarEPaginarDenunciasController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public FiltrarEPaginarDenunciasController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ListarDenunciaGetModel model)
        {
            try
            {
                var denuncias = _denunciaAppService.FiltrarEPaginarDenuncias(model);
                return StatusCode(200, new { message = "Denúncias listados com sucesso.", denuncias });
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
