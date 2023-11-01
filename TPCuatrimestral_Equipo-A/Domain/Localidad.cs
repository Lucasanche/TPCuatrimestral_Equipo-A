namespace Domain
{
    public partial class Localidad
    {
        public byte ID { get; set; }
        public string Nombre { get; set; }
        public byte IDProvincia { get; set; }
        public bool Estado { get; set; }
    }
}
