namespace Domain
{
    using System;
    public partial class Cliente
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Estado { get; set; }
        //data.SetQuery(@"SELECT ID, 
        //                               DNI, 
        //                               NOMBRE, 
        //                               APELIIDO,
        //                               EMAIL, 
        //                               TELEFONO_1, 
        //                               ISNULL(TELEFONO_2, 'Sin asignar'),
        //                               FECHA_NACIMIENTO,
        //                               FECHA_ALTA,
        //                               ISNULL(FECHA_BAJA, 'Sin asignar'),
        //                               ESTADO 
        //                        FROM CLIENTES");
    }
}
