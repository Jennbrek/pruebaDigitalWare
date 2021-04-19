using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            Compras = new HashSet<Compra>();
        }

        [Key]
        public int IdCliente { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(150)]
        public string Apellido { get; set; }
        public int IdTipoDocumento { get; set; }
        [Required]
        [StringLength(20)]
        public string Documento { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(50)]
        public string Correo { get; set; }
        public bool EstaActivo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaActualizacion { get; set; }

        [ForeignKey(nameof(IdTipoDocumento))]
        [InverseProperty(nameof(TipoDocumento.Clientes))]
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        [InverseProperty(nameof(Compra.IdClienteNavigation))]
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
