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
        [DisplayName("Descripción")]
        public string DescripcionInicial { get; set; }
        [DisplayName("Descripción al cierre")]
        public string DescripcionCierre { get; set; }
        [DisplayName("Legajo de usuario asignado")]
        public string LegajoUsuario { get; set; }
        [DisplayName("Usuario asignado")]
        public string NombreUsuario { get; set; }
        [DisplayName("Cliente afectado")]
        public Cliente ClienteAfectado { get; set; }
        [DisplayName("Fecha de creación")]
        public DateTime FechaCreacion { get; set; }
        [DisplayName("Fecha de cierre")]
        public DateTime? FechaCierre { get; set; }
        [DisplayName("Estado")]
        public EstadoReclamo Estado { get; set; }
    }
}
