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
    public class ClienteController : ControllerBase
    {
        private ClienteManager _clienteManager;

        public ClienteController(ApplicationDbContext _context)
        {
            _clienteManager = new ClienteManager(_context);
        }

        [HttpGet]
        public async Task<IList<ClienteDTO>> GetActive()
        {
            return await _clienteManager.GetAllActive();
        }
    }
}
