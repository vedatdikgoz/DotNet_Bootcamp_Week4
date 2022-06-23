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
    [SecuredOperation("admin")]
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }



        [CacheRemoveAspect("IProductService.Get")]
        public async Task<IResult> AddAsync(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _productRepository.AddAsync(product);
            return new SuccessResult(Messages.ProductAdded);
        }


       
        public async Task<IResult> DeleteAsync(int productId)
        {
            var product = await _productRepository.GetAsync(p => p.Id == productId);
            if (product!=null)
            {
                await _productRepository.DeleteAsync(product);               
                return new SuccessResult(Messages.ProductDeleted);
            }
            return new ErrorResult(Messages.ProductNotFound);
        }


        [CacheAspect]
        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetAsync(p => p.Id == id);
            return new SuccessDataResult<Product>(product, Messages.ProductListed);
        }



        [CacheAspect]   //Cache kullanmak için
        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return new SuccessDataResult<List<Product>>(products, Messages.ProductsListed);
        }

    
         
        [CacheRemoveAspect("IProductService.Get")]  //Cache deki get metodu ile gelen verileri siler
        public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            await _productRepository.UpdateAsync(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
      
    }
}
