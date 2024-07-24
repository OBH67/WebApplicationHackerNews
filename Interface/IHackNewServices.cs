using WebApplicationHacker.Class;
using WebApplicationHacker.Dto;

namespace WebApplicationHacker.Interface
{
    public interface IHackNewServices
    {
        Task<HackResultDto> HackNewResponse(HackNewResponse? objectData);
    }
}
