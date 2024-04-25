using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrarEPaginarDenunciasQuantidadeController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public FiltrarEPaginarDenunciasQuantidadeController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ListarDenunciaGetModel model)
        {
            try
            {
                var denunciasQuantidade = _denunciaAppService.FiltrarEPaginarDenunciasQuantidade(model);
                return StatusCode(200, new { message = "Quantidade de denúncias listados com sucesso.", denunciasQuantidade });
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
