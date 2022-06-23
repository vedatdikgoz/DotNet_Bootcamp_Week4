using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;


namespace DataAccess.Concrete
{
    public class ProductRepository : EntityRepositoryBase<Product,DataContext>, IProductRepository
    {


    }
}
