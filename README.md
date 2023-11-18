# avance_vsc
## Prueba Tecnica Desarrollador Junior Avance Software Company Bga
#### Queries en SQL
1. Listar las empresas que tienen más documentos fallidos que exitosos
``` sql
SELECT e.idempresa, e.razonsocial 
FROM empresa e 
JOIN numeracion n ON e.idempresa = n.idempresa 
JOIN documento d ON n.idnumeracion = d.idnumeracion
JOIN estado es ON d.idestado = es.idestado 
WHERE es.exitoso = false
GROUP BY e.idempresa, e.razonsocial 
HAVING COUNT(CASE WHEN es.exitoso = true THEN 1 END) < COUNT(CASE WHEN es.exitoso = false THEN 1 END) 
LIMIT 0, 1000;
```

2. Listar todas las empresas y cuántas facturas, notas débito y notas crédito se han generado entre dos fechas dadas
``` sql
SELECT e.idempresa, e.razonsocial,
SUM(CASE WHEN td.descripcion = 'Factura' THEN 1 ELSE 0 END) AS num_facturas,
SUM(CASE WHEN td.descripcion = 'Recibo' THEN 1 ELSE 0 END) AS num_recibos,
SUM(CASE WHEN td.descripcion = 'Nota de crédito' THEN 1 ELSE 0 END) AS num_notas_credito
FROM empresa e
JOIN numeracion n ON e.idempresa = n.idempresa
JOIN tipodocumento td ON n.idtipodocumento = td.idtipodocumento
JOIN documento d ON n.idnumeracion = d.idnumeracion
WHERE d.fecha BETWEEN '2023-01-01' AND '2023-12-31'
GROUP BY e.idempresa, e.razonsocial;
```

3. Listar todas las empresas y por cada una, la cantidad de documentos que están en cada uno de los estados
``` sql
SELECT e.idempresa, e.razonsocial, es.descripcion AS estado,
COUNT(d.iddocumento) AS cantidad_documentos
FROM empresa e
JOIN numeracion n ON e.idempresa = n.idempresa
JOIN documento d ON n.idnumeracion = d.idnumeracion
JOIN estado es ON d.idestado = es.idestado
GROUP BY e.idempresa, e.razonsocial, es.descripcion;
```

4. Listar las empresas que tienen más de 3 documentos no exitosos
```sql
SELECT e.idempresa, e.razonsocial 
FROM empresa e 
JOIN numeracion n ON e.idempresa = n.idempresa 
JOIN documento d ON n.idnumeracion = d.idnumeracion
JOIN estado es ON d.idestado = es.idestado
WHERE es.exitoso = false
GROUP BY e.idempresa, e.razonsocial 
HAVING COUNT(d.iddocumento) > 3
LIMIT 0, 1000;
```

5. Listar por cada empresa, cuántos documentos tienen número o fecha por fuera del rango y vigencia permitido por la DIAN
```sql
SELECT e.idempresa, e.razonsocial, COUNT(d.iddocumento) AS cantidad_documentos_fuera_de_rango
FROM empresa e
JOIN numeracion n ON e.idempresa = n.idempresa
JOIN documento d ON n.idnumeracion = d.idnumeracion
WHERE (d.numero < n.consecutivoinicial OR d.numero > n.consecutivofinal) OR (d.fecha < n.vigenciainicial OR d.fecha > n.vigenciafinal)
GROUP BY e.idempresa, e.razonsocial;
```

6. Teniendo en cuenta que las facturas suman y las notas débito suman, listar todas las empresas y el total de dinero recibido (base+impuestos). No incluir las notas crédito, ya que estas relacionan dinero que sale, no que entra
```sql
SELECT e.idempresa, e.razonsocial, 
SUM(CASE WHEN td.descripcion = 'Factura' THEN d.base + d.impuestos ELSE 0 END) AS total_dinero_recibido
FROM empresa e
JOIN numeracion n ON e.idempresa = n.idempresa
JOIN tipodocumento td ON n.idtipodocumento = td.idtipodocumento
JOIN documento d ON n.idnumeracion = d.idnumeracion
WHERE td.descripcion != 'Nota de crédito'
GROUP BY e.idempresa, e.razonsocial;
```

7. Teniendo en cuenta que el “número completo” de un documento es la concatenación de su prefijo y su número (ejemplo prefijo PRUE, número 654987, número completo es PRUE654987), determinar si hay algún “número completo” repetido en la base de datos (dos empresas pueden tener numeraciones con el mismo prefijo) y cuántas veces se repite
```sql
SELECT numero_completo, COUNT(numero_completo) AS repeticiones
FROM ( 
SELECT CONCAT(n.prefijo, d.numero) 
AS numero_completo
FROM numeracion n
JOIN documento d ON n.idnumeracion = d.idnumeracion) 
AS numeros_completos
GROUP BY numero_completo
HAVING COUNT(numero_completo) > 1;
```
