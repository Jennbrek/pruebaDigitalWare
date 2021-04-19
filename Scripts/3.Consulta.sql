---Obtener listado de todos los precio de los productos

select distinct Precio from Producto;

--Lista de productos con cantidad existente igual a 5
select * from Producto where CantidadExistente = 5;


--lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
select * 
from Cliente c, 
Compra f
where c.IdCliente = f.IdCliente
and Floor(DateDiff(d, FechaNacimiento, GetDate()) / 365.25) < 35
and f.Fecha between '2000/02/01' and '2000/05/25'

--valor total vendido por cada producto en el año 2000
select p.Nombre as Producto, sum(p.precio) as Precio 
from Producto p,
Compra_Producto cp,
Compra c
where p.IdProducto = cp.IdProducto
and c.IdCompra = cp.IdCompra
and YEAR(c.Fecha) = 2000
group by p.IdProducto, p.Nombre

--Obtener fecha de ultima compra del cliente
select MAX(f.Fecha), c.IdCliente
from Cliente c, 
Compra f
where c.IdCliente = f.IdCliente
group by c.IdCliente
