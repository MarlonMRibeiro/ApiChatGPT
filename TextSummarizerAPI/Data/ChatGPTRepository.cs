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
            url = "https://api.openai.com/v1/chat/completions";
        }

        public ChatGPTResponseViewModel PostText(string role, string content)
        {
            using (var request = new HttpClient())
            {
                request.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");

                var body = new ChatGPTViewModel()
                {
                    model = "",
                    messages = new List<Message>() 
                    { 
                        new Message() 
                        {
                            content = content, 
                            role= role
                        }
                    }
                };

                HttpContent httpcontent = JsonContent.Create(body);

                HttpResponseMessage response = request.PostAsync(url, httpcontent).Result;

                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                var resp = new ChatGPTResponseViewModel();

                JsonConvert.PopulateObject(response.Content.ReadAsStringAsync().Result, resp);

                return resp;
            }

        }
    }
}
