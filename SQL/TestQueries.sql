use CALL_CENTER
SELECT ID, 
                                       DNI, 
                                       NOMBRE, 
                                       APELLIDO,
                                       EMAIL, 
                                       TELEFONO_1, 
                                       ISNULL(TELEFONO_2, 'Sin asignar'),
                                       FECHA_NACIMIENTO,
                                       FECHA_ALTA,
                                       FECHA_BAJA,
                                       ESTADO 
                                FROM CLIENTES
                            