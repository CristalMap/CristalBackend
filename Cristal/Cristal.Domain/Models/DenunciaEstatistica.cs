using Cristal.Domain.Enum;

namespace Cristal.Domain.Models
{
    public class DenunciaEstatistica
    {
        private StatusDenuncia? _status;
        private long _quantidade;

        public StatusDenuncia? Status { get => _status; set => _status = value; }
        public long Quantidade { get => _quantidade; set => _quantidade = value; }
    }
}
