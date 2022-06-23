using Core.DataAccess.EntityFrameworkCore;
using Entities.Concrete;


namespace DataAccess.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {

    }
}
