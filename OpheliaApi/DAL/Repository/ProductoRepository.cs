using DAL.DataContext;
using DAL.Models;
using DAL.Repository.Contract;

namespace DAL.Repository
{
    public class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
