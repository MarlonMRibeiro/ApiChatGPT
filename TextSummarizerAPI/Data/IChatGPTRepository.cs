using TextSummarizerAPI.Data.ViewModels;

namespace TextSummarizerAPI.Data
{
    public interface IChatGPTRepository
    {
        ChatGPTResponseViewModel PostText(string role, string content);
    }
}
