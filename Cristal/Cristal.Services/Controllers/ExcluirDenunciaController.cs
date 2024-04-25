using Cristal.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cristal.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExcluirDenunciaController : ControllerBase
    {
        private readonly IDenunciaAppService _denunciaAppService;

        public ExcluirDenunciaController(IDenunciaAppService denunciaAppService)
        {
            _denunciaAppService = denunciaAppService;
        }

        [HttpDelete("{guid:guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                _denunciaAppService.ExcluirDenuncia(guid);
                return StatusCode(204, new { message = "Denúncia excluída com sucesso." });
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
