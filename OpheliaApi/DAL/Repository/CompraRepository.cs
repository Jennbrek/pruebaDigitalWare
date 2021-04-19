using DAL.DataContext;
using DAL.Models;
using DAL.Repository.Contract;

namespace DAL.Repository
{
    public class CompraRepository : RepositoryBase<Compra>, ICompraRepository
    {
        public CompraRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
