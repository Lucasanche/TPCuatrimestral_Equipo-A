namespace Domain
{
    using System;

    public partial class Ticket
    {
        public int ID { get; set; }
        public byte tipo_id { get; set; }
        public byte IDPrioridad { get; set; }
        public string DescripcionIncial { get; set; }
        public string DescripcionCierre { get; set; }
        public int UsuarioAsignado { get; set; }
        public int ClienteAfectado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public byte? IDEstado { get; set; }
        public bool Estado { get; set; }
    }
}
