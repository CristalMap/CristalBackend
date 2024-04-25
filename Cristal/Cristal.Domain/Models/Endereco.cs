namespace Cristal.Domain.Models
{
    public class Endereco
    {
        private Guid? _guid;
        private string? _nome;
        private double _latitude;
        private double _longitude;
        private List<Denuncia>? _denuncias;

        public Guid? Guid { get => _guid; set => _guid = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public double Latitude { get => _latitude; set => _latitude = value; }
        public double Longitude { get => _longitude; set => _longitude = value; }
        public List<Denuncia>? Denuncias { get => _denuncias; set => _denuncias = value; }
    }
}
