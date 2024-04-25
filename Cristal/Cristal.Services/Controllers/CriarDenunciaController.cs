using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CriarDenunciaController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public CriarDenunciaController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriarDenunciaPostModel model)
        {
            try
            {
                _denunciaAppService.CriarDenuncia(model);
                return StatusCode(201, new { message = "Denúncia cadastrada com sucesso." });
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
