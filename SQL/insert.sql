-- Insertar tres tipos de documentos relacionados al modelo
INSERT INTO tipodocumento (idtipodocumento, descripcion) VALUES
(1, 'Factura'),
(2, 'Recibo'),
(3, 'Nota de crédito');

-- Insertar siete estados de documentos relacionados al modelo
INSERT INTO estado (idestado, descripcion, exitoso) VALUES
(1, 'Generado', 1),
(2, 'En proceso', 1),
(3, 'Aprobado', 1),
(4, 'Rechazado', 0),
(5, 'Anulado', 0),
(6, 'Entregado', 1),
(7, 'Pagado', 1);

-- Crear tres empresas
INSERT INTO empresa (idempresa, identificacion, razonsocial) VALUES
(1, '123456789', 'Empresa A'),
(2, '987654321', 'Empresa B'),
(3, '111222333', 'Empresa C');

-- Crear seis numeraciones por empresa usando uniformemente en lo posible los tipos de documento permitidos
INSERT INTO numeracion (idnumeracion, idtipodocumento, idempresa, prefijo, consecutivoinicial, consecutivofinal, vigenciainicial, vigenciafinal) VALUES
(1, 1, 1, 'FAC', 1000, 1999, '2023-01-01', '2023-12-31'),
(2, 2, 1, 'REC', 2000, 2999, '2023-01-01', '2023-12-31'),
(3, 3, 1, 'NCR', 3000, 3999, '2023-01-01', '2023-12-31'),
(4, 1, 2, 'FAC', 5000, 5999, '2023-01-01', '2023-12-31'),
(5, 2, 2, 'REC', 6000, 6999, '2023-01-01', '2023-12-31'),
(6, 3, 2, 'NCR', 7000, 7999, '2023-01-01', '2023-12-31'),
(7, 1, 3, 'FAC', 9000, 9999, '2023-01-01', '2023-12-31'),
(8, 2, 3, 'REC', 10000, 10999, '2023-01-01', '2023-12-31'),
(9, 3, 3, 'NCR', 11000, 11999, '2023-01-01', '2023-12-31');

-- Crear seis documentos por numeración usando uniformemente en lo posible los estados permitidos
INSERT INTO documento (iddocumento, idestado, idnumeracion, numero, fecha, base, impuestos) VALUES 
(1, 1, 1, 1001, '2023-01-02', 1001.00, 150.00),
(2, 2, 2, 2001, '2023-01-03', 500.00, 75.00),
(3, 3, 3, 3001, '2023-01-04', 200.00, 30.00),
(4, 4, 4, 5001, '2023-01-05', 1200.00, 180.00),
(5, 5, 5, 6001, '2023-01-06', 700.00, 105.00),
(6, 6, 6, 7001, '2023-01-07', 300.00, 45.00),
(7, 1, 7, 9001, '2023-01-08', 1500.00, 225.00),
(8, 2, 8, 10001, '2023-01-09', 800.00, 120.00),
(9, 3, 9, 11001, '2023-01-10', 400.00, 60.00);