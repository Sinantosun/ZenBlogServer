namespace ZenBlog.Application.Contracts.Persistence
{
    public interface IHugginFaceService
    {
        Task<string> GetTranslatedText(string text);
        Task<byte> AnalizeComment(string text);
    }
}
