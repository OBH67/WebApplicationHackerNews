using Microsoft.AspNetCore.Mvc;
using WebApplicationHacker.Dto;
using Newtonsoft.Json;
using System.Text;
using WebApplicationHacker.Class;
using WebApplicationHacker.Interface;
using System.Numerics;

namespace WebApplicationHacker.Controllers
{
    [ApiController]
    [Route("HackNews")]
    public class HackNewsController : ControllerBase
    {
        private readonly IServices _services;

        public HackNewsController(IServices services)
        {
            _services = services;
        }


        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns>list of hack news</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<HackResultDto>> Get()
        {         
            var listData = await this._services.GetHackList();
            return listData;
        }


        /// <summary>
        /// Get Hack news base on the id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Find a hack new base on the ID</returns>
        [HttpGet]
        [Route("GetDataById")]
        public async Task<HackResultDto> GetDataById(int Id)
        {
            var data = await this._services.GetHackNewById(Id);
            return data;
        }

        /// <summary>
        /// Get Hack news base on the a list of ids
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Find one or more hack news base on a list of IDs</returns>
        [HttpPost]
        [Route("GetDataByIds")]
        public async Task<List<HackResultDto>> GetPostDataByIds([FromBody] List<int> Id)
        {
            var listData = await this._services.GetHackByIds(Id);
            return listData;
        }
    }
}
