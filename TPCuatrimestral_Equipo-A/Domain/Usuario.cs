namespace Domain
{
    using System;
    using System.Collections.Generic;

    public partial class Usuario
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public Rol Rol { get; set; }
        public sbyte Estado { get; set; }
    }
}
