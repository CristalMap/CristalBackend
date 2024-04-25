using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarDenunciaController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public AtualizarDenunciaController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpPut("{guid:guid}")]
        public IActionResult Put(Guid guid, [FromBody] AtualizarDenunciaPutModel model)
        {
            try
            {
                var denuncia = _denunciaAppService.AtualizarDenuncia(guid, model);
                return StatusCode(200, new { message = "Denúncia atualizada com sucesso.", denuncia });
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
