use CALL_CENTER

INSERT INTO PROVINCIAS (NOMBRE, ESTADO)
VALUES
    ('Buenos Aires', 1),
    ('Catamarca', 1),
    ('Chaco', 1),
    ('Chubut', 1),
    ('Córdoba', 1),
    ('Corrientes', 1),
    ('Entre Ríos', 1),
    ('Formosa', 1),
    ('Jujuy', 1),
    ('La Pampa', 1),
    ('La Rioja', 1),
    ('Mendoza', 1),
    ('Misiones', 1),
    ('Neuquén', 1),
    ('Río Negro', 1),
    ('Salta', 1),
    ('San Juan', 1),
    ('San Luis', 1),
    ('Santa Cruz', 1),
    ('Santa Fe', 1),
    ('Santiago del Estero', 1),
    ('Tierra del Fuego', 1),
    ('Tucumán', 1)

INSERT INTO [dbo].[CLIENTES] (DNI, NOMBRE, APELLIDO, EMAIL, TELEFONO_1, TELEFONO_2, FECHA_NACIMIENTO, FECHA_ALTA, FECHA_BAJA, ESTADO)
VALUES
('1234567890', 'Juan', 'Pérez', 'juan@example.com', '1234567890', NULL, '1990-01-15', '2023-11-06', NULL, 1),
('9876543210', 'María', 'González', 'maria@example.com', '9876543210', NULL, '1985-03-20', '2023-11-06', NULL, 1),
('4567891230', 'Luis', 'Martínez', 'luis@example.com', '4567891230', NULL, '1978-08-10', '2023-11-06', NULL, 1),
('7891234560', 'Ana', 'Rodríguez', 'ana@example.com', '7891234560', NULL, '1982-12-05', '2023-11-06', NULL, 1),
('2345678901', 'Carlos', 'Sánchez', 'carlos@example.com', '2345678901', NULL, '1995-06-25', '2023-11-06', NULL, 1),
('3456789012', 'Laura', 'López', 'laura@example.com', '3456789012', '531571351', '1980-04-30', '2023-11-06', NULL, 1),
('5678901234', 'Pedro', 'Fernández', 'pedro@example.com', '5678901234', NULL, '1992-09-18', '2023-11-06', NULL, 1),
('6789012345', 'Cecilia', 'Díaz', 'cecilia@example.com', '6789012345', NULL, '1987-07-12', '2023-11-06', NULL, 1),
('8901234567', 'Diego', 'Torres', 'diego@example.com', '8901234567', NULL, '1989-11-08', '2023-11-06', NULL, 1),
('1234512345', 'Valeria', 'Ramírez', 'valeria@example.com', '1234512345', NULL, '1998-02-14', '2023-11-06', NULL, 1);


INSERT INTO [dbo].[PRIORIDADES] (ID, NOMBRE, ESTADO)
VALUES
(1, 'Alta', 1),
(2, 'Media', 1),
(3, 'Baja', 1),
(4, 'Urgente', 1),
(5, 'Crítica', 1);


INSERT INTO [dbo].[TIPOS_INCIDENCIA] (ID, NOMBRE, ESTADO)
VALUES
(1, 'Soporte Técnico', 1),
(2, 'Solicitud de Información', 1),
(3, 'Incidente', 1),
(4, 'Mantenimiento', 1),
(5, 'Facturación', 1);

INSERT INTO [dbo].[ESTADOS_TICKET] (ID, NOMBRE, ESTADO)
VALUES
(1, 'Pendiente de revisión', 1),
(2, 'En proceso', 1),
(3, 'Cerrado resuelto', 1),
(4, 'Cerrado sin resolución', 1);





INSERT INTO [dbo].[TICKETS] (ID_TIPO, ID_PRIORIDAD, DESCRIPCION_INICIAL, DESCRIPCION_CIERRE, USUARIO_ASIGNADO, CLIENTE_AFECTADO, FECHA_INICIO, FECHA_FIN, ID_ESTADO)
VALUES
(1, 1, 'Problema con el correo', NULL, 2, 3, '2023-11-06', NULL, 2),
(2, 2, 'Error en el software', NULL, 1, 4, '2023-11-06', NULL, 1),
(3, 1, 'Solicitud de asistencia', NULL, 4, 5, '2023-11-06', NULL, 3),
(4, 3, 'Problema de red', NULL, 3, 1, '2023-11-06', NULL, 2),
(5, 2, 'Problema con la impresora', NULL, 2, 2, '2023-11-06', NULL, 1),
(1, 3, 'Solicitud de información', NULL, 1, 4, '2023-11-06', NULL, 3),
(2, 1, 'Error en el sitio web', NULL, 3, 3, '2023-11-06', NULL, 2),
(3, 4, 'Solicitud de mantenimiento', NULL, 4, 5, '2023-11-06', NULL, 1),
(4, 5, 'Problema crítico en el servidor', NULL, 2, 1, '2023-11-06', NULL, 3),
(5, 1, 'Solicitud de facturación', NULL, 1, 2, '2023-11-06', NULL, 2);



INSERT INTO [dbo].[ROLES] (ID, DESCRIPCION, ESTADO)
VALUES
(1, 'Telefonista', 1),
(2, 'Supervisor', 1),
(3, 'Administrador', 1);

INSERT INTO [dbo].[USUARIOS] (DNI, NOMBRE, APELLIDO, EMAIL, PASSWORD, FECHA_INICIO, ROL, ESTADO)
VALUES
('1234567890', 'Lucas', 'Sanchez', 'lucas@sanchez.com', 'password', '2023-11-06', 1, 1),
('9876543210', 'Mariano', 'Visgarra', 'mariano@visgarra.com', 'password', '2023-11-06', 2, 1),
('4567891230', 'Luis', 'Martínez', 'luis@example.com', 'password', '2023-11-06', 3, 1),
('7891234560', 'Ana', 'Rodríguez', 'ana@example.com', 'password', '2023-11-06', 3, 1),
('2345678901', 'Carlos', 'Sánchez', 'carlos@example.com', 'password', '2023-11-06', 3, 1);



-- Insertar domicilios relacionados con provincias
INSERT INTO [dbo].[DOMICILIOS] (ID_PROVINCIA, CIUDAD, NOMBRE_CALLE, NUMERO, PISO, DEPARTAMENTO, ENTRECALLE_1, ENTRECALLE_2, OBSERVACION)
VALUES
(1, 'La Plata', 'Calle 1', 123, 4, 'Dpto. A', 'Calle 2', 'Calle 3', 'Observación 1'),
(5, 'Córdoba', 'Avenida Principal', 567, NULL, NULL, 'Calle 4', 'Calle 5', 'Observación 2'),
(16, 'Neuquén', 'Calle Principal', 789, 2, 'Dpto. B', 'Calle 6', 'Calle 7', 'Observación 3'),
(4, 'Comodoro Rivadavia', 'Avenida Central', 456, NULL, NULL, 'Calle 8', 'Calle 9', 'Observación 4'),
(10, 'La Pampa', 'Calle Central', 321, 3, 'Dpto. C', 'Calle 10', 'Calle 11', 'Observación 5'),
(21, 'San Fernando del Valle', 'Avenida Norte', 987, 5, 'Dpto. D', 'Calle 12', 'Calle 13', 'Observación 6'),
(9, 'Jujuy', 'Calle Sur', 654, 6, 'Dpto. E', 'Calle 14', 'Calle 15', 'Observación 7'),
(7, 'Gualeguaychú', 'Avenida Oeste', 432, 1, 'Dpto. F', 'Calle 16', 'Calle 17', 'Observación 8'),
(23, 'Ushuaia', 'Avenida del Fin', 789, 7, 'Dpto. G', 'Calle 18', 'Calle 19', 'Observación 9'),
(3, 'Resistencia', 'Calle Principal', 567, NULL, NULL, 'Calle 20', 'Calle 21', 'Observación 10');


INSERT INTO [dbo].[CLIENTES_X_DOMICILIOS] (ID_CLIENTE, ID_DOMICILIO, ESTADO)
VALUES
(4, 6, 1),
(5, 7, 1),
(6, 8, 1),
(7, 9, 1),
(8, 10, 1),
(9, 11, 1),
(10, 12, 1),
(11, 13, 1),
(12, 14, 1),
(13, 15, 1);