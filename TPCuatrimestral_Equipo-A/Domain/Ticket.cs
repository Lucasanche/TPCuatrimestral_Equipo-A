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
    //data.SetQuery(@"SELECT ID, 
    //                               ID_TIPO,
    //                               ISNULL(ID_TIPO, 'Otro'),
    //                               ID_PRIORIDAD,
    //                               ISNULL(ID_PRIORIDAD, 0),
    //                               DESCRIPCION_INICIAL,
    //                               DESCRIPCION_CIERRE, 
    //                               ISNULL(DESCRIPCION_CIERRE, 'Cerrado sin descripcion'),
    //                               USUARIO_ASIGNADO, 
    //                               CLIENTE_AFECTADO,
    //                               FECHA_INICIO,
    //                               FECHA_FIN,
    //                               ID_ESTADO,
    //                               ESTADO
    //                        FROM RECLAMOS");
}
