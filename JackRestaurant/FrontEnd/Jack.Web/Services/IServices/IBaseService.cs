using Jack.Web.Models;
using Jack.Web.Models.Dto;

namespace Jack.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
