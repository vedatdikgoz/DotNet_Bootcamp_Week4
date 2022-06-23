using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;


namespace DataAccess.Concrete
{
    public class CategoryRepository : EntityRepositoryBase<Category, DataContext>, ICategoryRepository
    {

    }
}
