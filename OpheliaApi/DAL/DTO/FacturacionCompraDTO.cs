using System;
using System.Collections.Generic;

namespace DAL.DTO
{
    public class FacturacionCompraDTO
    {
        public int IdCompra { get; set; }

        public ClienteDTO Cliente { get; set; }

        public string FechaCompra { get; set; }

        public decimal ValorCompra { get; set; }

        public int CantidadProductos { get; set; }

        public List<ProductoDTO> Productos { get; set; }
    }
}
