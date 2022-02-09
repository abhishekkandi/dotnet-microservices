using Jack.Web.Models;
using Jack.Web.Models.Dto;
using Jack.Web.Services.IServices;
using static Jack.Web.SD;

namespace Jack.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.POST,
                Data = productDto,
                Url = ProductAPIBase + "/api/products",
                AccessToken = string.Empty//For time being
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.DELETE,
                Url = ProductAPIBase + "/api/products/" + id,
                AccessToken = string.Empty//For time being
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + "/api/products/" + id,
                AccessToken = string.Empty//For time being
            });
        }

        public async Task<T> GetProductsAsync<T>()
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.GET,
                Url = ProductAPIBase + "/api/products",
                AccessToken = string.Empty//For time being
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = ApiType.PUT,
                Data = productDto,
                Url = ProductAPIBase + "/api/products",
                AccessToken = string.Empty//For time being
            });
        }
    }
}
