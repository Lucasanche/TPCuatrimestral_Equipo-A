namespace Domain
{
    using System;
    public partial class Usuario
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string APELLIDO { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono_1 { get; set; }
        public string Telefono_2 { get; set; }
        public DateTime FechaInicio { get; set; }
        public byte Rol { get; set; }
        public bool Estado { get; set; }
    }
}
