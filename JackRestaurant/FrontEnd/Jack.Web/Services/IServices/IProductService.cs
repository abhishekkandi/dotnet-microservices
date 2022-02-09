using Jack.Web.Models.Dto;

namespace Jack.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
