namespace Domain
{
    using System;
    using System.Collections.Generic;

    public partial class Usuario
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public Rol Rol { get; set; }
        public bool Estado { get; set; }
        public string NombreCompleto()
        {
            string nombreCompleto = Nombre + ' ' + Apellido;
            return nombreCompleto;
        }
    }
}
