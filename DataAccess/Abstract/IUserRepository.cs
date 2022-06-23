using Core.DataAccess.EntityFrameworkCore;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
