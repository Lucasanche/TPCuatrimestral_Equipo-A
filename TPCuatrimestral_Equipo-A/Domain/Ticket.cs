namespace Domain
{
    using System;

    public partial class Ticket
    {
        public int ID { get; set; }
        public TipoTicket Tipo { get; set; }
        public byte IDPrioridad { get; set; }
        public string DescripcionIncial { get; set; }
        public string DescripcionCierre { get; set; }
        public Usuario UsuarioAsignado { get; set; }
        public Cliente ClienteAfectado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public EstadoReclamo Estado { get; set; }
    }
}
