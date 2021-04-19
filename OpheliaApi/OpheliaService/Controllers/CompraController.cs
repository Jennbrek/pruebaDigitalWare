using BLL;
using DAL.DataContext;
using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpheliaService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private CompraManager _compraManager;

        public CompraController(ApplicationDbContext _context)
        {
            _compraManager = new CompraManager(_context);
        }

        [HttpGet]
        public async Task<IList<FacturacionCompraDTO>> Get()
        {
            return await _compraManager.GetAll();
        }

        [HttpGet]
        [Route("VerDetalle")]
        public async Task<FacturacionCompraDTO> Detail(int id)
        {
            return await _compraManager.Find(id);
        }

        [HttpPost]
        public int Create(FacturacionCompraDTO facturacionCompra)
        {
            return _compraManager.Create(facturacionCompra);
        }

        [HttpPut]
        public async Task Update(FacturacionCompraDTO facturacionCompra)
        {
            await _compraManager.Update(facturacionCompra);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task Delete(int id)
        {
            await _compraManager.Delete(id);
        }
    }
}
