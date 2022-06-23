using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos;


namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAllAsync();
        Task<IDataResult<Category>> GetByIdAsync(int id);
        Task<IResult> AddAsync(CategoryAddDto categoryAddDto);
        Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<IResult> DeleteAsync(int categoryId);
    }
}
