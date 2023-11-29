namespace Domain
{
    public partial class EstadoReclamo
    {
        public byte ID { get; set; }
        public string Nombre { get; set; }
        public EstadoReclamo()
        {
            this.ID = 1;
            this.Nombre = "Pendiente de revisión";
        }

    }
}
