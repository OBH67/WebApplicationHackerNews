using Newtonsoft.Json;
using WebApplicationHacker.Class;
using WebApplicationHacker.Interface;

namespace WebApplicationHacker.Services
{
    public class HttpHackNewServices : IHttpHackNewServices
    {
        public async Task<HackNewResponse> HttpHackGetData(int Id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{Id}.json");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var objectData = JsonConvert.DeserializeObject<HackNewResponse>(responseBody);

            if (objectData != null)
            {
                return objectData;
            } else
            {
                throw new InvalidOperationException("Hacker news API don´t return data.");
            }
        }

        public async Task<string> HttpHackGetAllData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://hacker-news.firebaseio.com/v0/beststories.json");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody != null)
            {
                return responseBody;
            }
            else
            {
                throw new InvalidOperationException("Hacker news API don´t return data.");
            }
        }
    }
}

