using WebApplicationHacker.Class;
using WebApplicationHacker.Dto;

namespace WebApplicationHacker.Interface
{
    public interface IHttpHackNewServices
    {
        Task<HackNewResponse> HttpHackGetData(int Id);

        Task<string> HttpHackGetAllData();
    }
}
