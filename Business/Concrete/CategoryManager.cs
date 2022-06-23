using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Concrete
{
    
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [CacheRemoveAspect("ICategoryService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            await _categoryRepository.AddAsync(category);
            return new SuccessResult(Messages.CategoryAdded);
        }



        [SecuredOperation("admin")]
        public async Task<IResult> DeleteAsync(int categoryId)
        {
            var category= await _categoryRepository.GetAsync(c=>c.Id==categoryId);
            if (category != null)
            {
                await _categoryRepository.DeleteAsync(category);
                return new SuccessResult(Messages.CategoryDeleted);
            }
            return new ErrorResult(Messages.CategoryNotFound);
        }


        [CacheAspect]   //Cache kullanmak için
        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return new SuccessDataResult<List<Category>>(categories, Messages.CategoriesListed);
        }


        [CacheAspect]
        [SecuredOperation("admin")]
        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Category>(await _categoryRepository.GetAsync(c => c.Id == id), Messages.CategoryListed);
        }



        [CacheRemoveAspect("ICategoryService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            await _categoryRepository.UpdateAsync(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
