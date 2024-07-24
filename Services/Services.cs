using WebApplicationHacker.Class;
using WebApplicationHacker.Dto;
using WebApplicationHacker.Interface;

namespace WebApplicationHacker.Services
{
    public class Services : IServices
    {
        private readonly IHttpHackNewServices _httpHackNewServices;
        private readonly IHackNewServices _hackNewServices;

        public Services(IHttpHackNewServices httpHackNewServices, IHackNewServices hackNewServices)
        {
            _httpHackNewServices = httpHackNewServices;
            _hackNewServices = hackNewServices;
        }

        public async Task<List<HackResultDto>> GetHackList()
        {
            // Service to get data from Hack news api
            var responseBody = await this._httpHackNewServices.HttpHackGetAllData();

            // Variables
            string[] result = responseBody.Split('[', ',', ']');
            var list = result.ToList();
            list.RemoveAll(x => string.IsNullOrEmpty(x));
            int Id = 0;
            var data = new HackNewResponse();
            var listData = new List<HackNewResponse>();
            var dataNew = new HackResultDto();
            var dataNewList = new List<HackResultDto>();

            // Create result list
            foreach (var item in list)
            {
                Id = Int32.Parse(item);
                data = await this._httpHackNewServices.HttpHackGetData(Id);
                dataNew = await this._hackNewServices.HackNewResponse(data);
                dataNewList.Add(dataNew);
            }

            // List of hack news
            return dataNewList;
        }

        public async Task<HackResultDto> GetHackNewById(int Id)
        {
            // Get data from a specific ID
            var result = await this._httpHackNewServices.HttpHackGetData(Id);
            var objectData = await this._hackNewServices.HackNewResponse(result);

            // return data
            return objectData;
        }

        public async Task<List<HackResultDto>> GetHackByIds(List<int> Id)
        { 
            // Variables
            var result = new HackNewResponse();
            var objectData = new HackResultDto();
            var list = new List<HackResultDto>();

            // Get data from a multiple IDs
            foreach (var item in Id)
            {
                result = await this._httpHackNewServices.HttpHackGetData(item);
                objectData = await this._hackNewServices.HackNewResponse(result);
                list.Add(objectData);
            }
           
            return list;
        }
    }
}
