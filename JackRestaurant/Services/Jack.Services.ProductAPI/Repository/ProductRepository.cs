using AutoMapper;
using Jack.Services.ProductAPI.DbContexts;
using Jack.Services.ProductAPI.Models;
using Jack.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Jack.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public ProductRepository(ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            
            if(product.ProductId > 0)            
                _dbContext.Products.Update(product);            
            else
                _dbContext.Products.Add(product);
            
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _dbContext.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
                if (product == null)
                    return false;

                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _dbContext.Products.Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable<Product> products = await _dbContext.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
