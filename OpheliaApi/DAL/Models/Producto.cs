using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Models
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            CompraProductos = new HashSet<CompraProducto>();
        }

        [Key]
        public int IdProducto { get; set; }
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }
        [StringLength(250)]
        public string Descripcion { get; set; }
        [Required]
        public bool? EstaActivo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaActualizacion { get; set; }
        public int Cantidad { get; set; }
        public int CantidadExistente { get; set; }

        [InverseProperty(nameof(CompraProducto.IdProductoNavigation))]
        public virtual ICollection<CompraProducto> CompraProductos { get; set; }
    }
}
