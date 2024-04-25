using Cristal.Application.Interfaces;
using Cristal.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MudarStatusDenunciaController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public MudarStatusDenunciaController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpPut("{guid:guid}")]
        public IActionResult Put(Guid guid, [FromBody] StatusDenuncia model)
        {
            try
            {
                _denunciaAppService.MudarStatusDenuncia(guid, model);
                return StatusCode(200, new { message = "Denúncia atualizada com sucesso." });
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
