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
        public byte IdEstadoReclamo { get; set; }
        public EstadoReclamo Estado { get; set; }
        public Ticket()
        {
            ID = 0;
            Tipo = new TipoTicket();
            Prioridad = new Prioridad();
            DescripcionInicial = "";
            DescripcionCierre = "";
            LegajoUsuario = "";
            NombreUsuario = "";
            ClienteAfectado = new Cliente();
            FechaCreacion = new DateTime();
            FechaCierre = new DateTime();
            Estado = new EstadoReclamo();
        }
        public Ticket(Ticket ticket)
        {
            this.ID = ticket.ID;
            this.Tipo = ticket.Tipo;
            this.Prioridad = ticket.Prioridad;
            this.DescripcionInicial = ticket.DescripcionInicial;
            this.DescripcionCierre = ticket.DescripcionCierre;
            this.LegajoUsuario = ticket.LegajoUsuario;
            this.NombreUsuario = ticket.NombreUsuario;
            this.ClienteAfectado = ticket.ClienteAfectado;
            this.FechaCreacion = ticket.FechaCreacion;
            this.FechaCierre = ticket.FechaCierre;
            this.IdEstadoReclamo = ticket.Estado.ID;
            this.Estado = ticket.Estado;
        }
    }

}
