using DAL.DataContext;
using DAL.Models;
using DAL.Repository.Contract;

namespace DAL.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
