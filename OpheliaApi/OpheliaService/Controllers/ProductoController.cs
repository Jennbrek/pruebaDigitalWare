using BLL;
using DAL.DataContext;
using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpheliaService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private ProductoManager _productoManager;

        public ProductoController(ApplicationDbContext _context)
        {
            _productoManager = new ProductoManager(_context);
        }

        [HttpGet]
        public async Task<IList<ProductoDTO>> GetActive()
        {
            return await _productoManager.GetAllActive();
        }
    }
}
