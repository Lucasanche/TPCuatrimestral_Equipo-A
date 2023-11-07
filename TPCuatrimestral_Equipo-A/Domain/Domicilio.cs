using System.Collections.Generic;

namespace Domain
{
    public partial class Domicilio
    {
        public int ID { get; set; }
        public string NombreCalle { get; set; }
        public string Numero { get; set; }
        public byte? Piso { get; set; }
        public string Departamento { get; set; }
        public string Entrecalle1 { get; set; }
        public string Entrecalle2 { get; set; }
        public string Observacion { get; set; }
        public string Ciudad { get; set; }
        public List<Cliente> Cliente { get; set; }
    }
}
