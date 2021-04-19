namespace DAL.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int CantidadExistente { get; set; }
        public bool EstaActivo { get; set; }
    }
}
