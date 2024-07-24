using WebApplicationHacker.Class;
using WebApplicationHacker.Dto;

namespace WebApplicationHacker.Interface
{
    public interface IServices
    {
        Task<HackResultDto> GetHackNewById(int Id);

        Task<List<HackResultDto>> GetHackByIds(List<int> Id);

        Task<List<HackResultDto>> GetHackList();
    }
}
