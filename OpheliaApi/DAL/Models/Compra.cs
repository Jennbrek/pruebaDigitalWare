using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Models
{
    [Table("Compra")]
    public partial class Compra
    {
        public Compra()
        {
            CompraProductos = new HashSet<CompraProducto>();
        }

        [Key]
        public int IdCompra { get; set; }
        public int IdCliente { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.Compras))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [InverseProperty(nameof(CompraProducto.IdCompraNavigation))]
        public virtual ICollection<CompraProducto> CompraProductos { get; set; }
    }
}
