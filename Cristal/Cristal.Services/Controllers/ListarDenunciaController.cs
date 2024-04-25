using Cristal.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ListarDenunciaController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public ListarDenunciaController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var denuncias = _denunciaAppService.ListarDenuncias();
                return StatusCode(200, new { message = "Denúncias listadas com sucesso.", denuncias });
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
