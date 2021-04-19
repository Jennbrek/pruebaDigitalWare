using DAL.DataContext;
using DAL.DTO;
using DAL.Repository;
using DAL.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoManager
    {
        private IProductoRepository _productoRepository;

        public ProductoManager(ApplicationDbContext context)
        {
            _productoRepository = new ProductoRepository(context);
        }

        public async Task<IList<ProductoDTO>> GetAllActive()
        {
            try
            {
                List<ProductoDTO> productos = await _productoRepository.FindByCondition(x => x.EstaActivo == true).
                    Select(p => new ProductoDTO
                    {
                        IdProducto = p.IdProducto,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        Precio = p.Precio,
                        Cantidad = p.Cantidad,
                        CantidadExistente = p.CantidadExistente
                    }).ToListAsync();

                return productos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
