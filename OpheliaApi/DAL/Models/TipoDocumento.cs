using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Models
{
    [Table("TipoDocumento")]
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        public int IdTipoDocumento { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Cliente.IdTipoDocumentoNavigation))]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
