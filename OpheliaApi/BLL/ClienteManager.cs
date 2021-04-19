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
    public class ClienteManager
    {

        private IClienteRepository _clienteRepository;

        public ClienteManager(ApplicationDbContext context)
        {
            _clienteRepository = new ClienteRepository(context);
        }

        public async Task<IList<ClienteDTO>> GetAllActive()
        {
            try
            {
                List<ClienteDTO> clientes = await _clienteRepository.FindByCondition(x => x.EstaActivo == true)
                    .Include(tipoDoc => tipoDoc.IdTipoDocumentoNavigation)
                    .Select(cliente => new ClienteDTO
                    {
                        IdCliente = cliente.IdCliente,
                        Apellido = cliente.Apellido,
                        Nombre = cliente.Nombre,
                        Documento = cliente.Documento,
                        TipoDocumento = cliente.IdTipoDocumentoNavigation.Nombre
                    }).ToListAsync();

                return clientes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
