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
        public string DescripcionInicial { get; set; }
        [DisplayName("Descripci�n al cierre")]
        public string DescripcionCierre { get; set; }
        [DisplayName("Legajo de usuario asignado")]
        public string LegajoUsuario { get; set; }
        [DisplayName("Usuario asignado")]
        public string NombreUsuario { get; set; }
        [DisplayName("Cliente afectado")]
        public Cliente ClienteAfectado { get; set; }
        [DisplayName("Fecha de creaci�n")]
        public DateTime FechaCreacion { get; set; }
        [DisplayName("Fecha de cierre")]
        public DateTime? FechaCierre { get; set; }
        [DisplayName("Estado")]
        public byte IdEstadoReclamo { get; set; }
        public EstadoReclamo Estado { get; set; }
        public Ticket()
        {
            ID= 0;
            Tipo= new TipoTicket();
            Prioridad   = new Prioridad();
            DescripcionInicial = "";
            DescripcionCierre = "";
            LegajoUsuario = "";
            NombreUsuario = "";
            ClienteAfectado = new Cliente();
            FechaCreacion = new DateTime();
            FechaCierre = new DateTime();
            Estado = new EstadoReclamo();
        }
    }

}
