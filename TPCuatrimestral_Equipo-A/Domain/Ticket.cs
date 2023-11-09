namespace Domain
{
    using System;
    using System.ComponentModel;

    public partial class Ticket
    {
        [DisplayName("Id")]
        public int ID { get; set; }
        [DisplayName("Tipo")]
        public TipoTicket Tipo { get; set; }
        [DisplayName("Prioridad")]
        public Prioridad Prioridad { get; set; }
        [DisplayName("Descripci�n")]
        public string DescripcionIncial { get; set; }
        [DisplayName("Descripci�n al cierre")]
        public string DescripcionCierre { get; set; }
        [DisplayName("Legajo de usuario asignado")]
        public string LegajoUsuario { get; set; }
        [DisplayName("Usuario asignado")]
        public string NombreUsuario { get; set; }
        [DisplayName("Cliente afectado")]
        public Cliente ClienteAfectado { get; set; }
        [DisplayName("Fecha de creaci�n")]
        public DateTime FechaInicio { get; set; }
        [DisplayName("Fecha de cierre")]
        public DateTime? FechaFin { get; set; }
        [DisplayName("Estado")]
        public EstadoReclamo Estado { get; set; }
    }
}
