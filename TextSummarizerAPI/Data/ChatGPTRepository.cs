using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using TextSummarizerAPI.Data.ViewModels;

namespace TextSummarizerAPI.Data
{
    public class ChatGPTRepository : IChatGPTRepository
    {
        private readonly string url;
        public ChatGPTRepository()
        {
            url = "";
        }

        public ChatGPTResponseViewModel PostText(string content, string role = null)
        {
            using (var request = new HttpClient())
            {
                request.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");

                HttpResponseMessage response = request.GetAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var resp = new ChatGPTResponseViewModel();

                JsonConvert.PopulateObject(response.Content.ReadAsStringAsync().Result, resp);

                return resp;
            }

        }
    }
}
