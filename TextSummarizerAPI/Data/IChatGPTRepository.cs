using TextSummarizerAPI.Data.ViewModels;

namespace TextSummarizerAPI.Data
{
    public interface IChatGPTRepository
    {
        ChatGPTResponseViewModel PostText(string content, string role = null);
    }
}
