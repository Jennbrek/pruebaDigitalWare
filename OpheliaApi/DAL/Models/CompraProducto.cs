using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Models
{
    [Table("Compra_Producto")]
    public partial class CompraProducto
    {
        [Key]
        public int IdCompra { get; set; }
        [Key]
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey(nameof(IdCompra))]
        [InverseProperty(nameof(Compra.CompraProductos))]
        public virtual Compra IdCompraNavigation { get; set; }
        [ForeignKey(nameof(IdProducto))]
        [InverseProperty(nameof(Producto.CompraProductos))]
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
