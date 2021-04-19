using System;

namespace DAL.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
    }
}
