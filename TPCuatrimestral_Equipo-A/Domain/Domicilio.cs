namespace Domain
{
    public partial class Domicilio
    {
        public int ID { get; set; }
        public byte IDProvincia { get; set; }
        public byte IDLocalidad { get; set; }
        public string NombreCalle { get; set; }
        public byte? Numero { get; set; }
        public byte? Piso { get; set; }
        public string Departamento { get; set; }
        public string Entrecalle1 { get; set; }
        public string Entrecalle2 { get; set; }
        public string Observacion { get; set; }
    }
}
