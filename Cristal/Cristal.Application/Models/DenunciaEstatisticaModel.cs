using Cristal.Domain.Enum;

namespace Cristal.Application.Models
{
    public class DenunciaEstatisticaModel
    {
        public StatusDenuncia Status { get; set; }
        public long Quantidade { get; set; }
    }
}
