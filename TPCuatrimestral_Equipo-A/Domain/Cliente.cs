namespace Domain
{
    using System;
    using System.Xml.Linq;

    public partial class Cliente
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { 
            get { return $"{Nombre} {Apellido}"; }  }
        public string Email { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public sbyte Estado { get; set; }
    }
}
