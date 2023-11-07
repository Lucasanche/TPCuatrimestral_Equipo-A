namespace Domain
{
    using System;
    using System.Collections.Generic;

    public partial class Usuario
    {
        public int ID { get; set; }
        public string Legajo { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaInicio { get; set; }
        public List<Domicilio>Domicilios { get; set; }
        public Rol Rol { get; set; }
        public bool Estado { get; set; }
    }
}
