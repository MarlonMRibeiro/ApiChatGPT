using Microsoft.AspNetCore.Mvc;
using TextSummarizerAPI.Data;

namespace TextSummarizerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ILogger<ChatController> _logger;
        private readonly IChatGPTRepository _chatGPTRepository;

        public ChatController(ILogger<ChatController> logger, IChatGPTRepository chatGPTRepository)
        {
            _logger = logger;
            _chatGPTRepository = chatGPTRepository;
        }

        [HttpPost]
        public string PostText(string role, string content)
        {
            return _chatGPTRepository.PostText(role, content).choices.FirstOrDefault().message.content;
        }
    }
}