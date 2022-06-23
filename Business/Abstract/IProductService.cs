using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos;


namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<Product>>> GetAllAsync();
        Task<IDataResult<Product>> GetByIdAsync(int id);
        Task<IResult> AddAsync(ProductAddDto productAddDto);
        Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<IResult> DeleteAsync(int productId);

    }
}
