namespace SSIGlass.Contract.Services
{
    public interface IGraphicViewService : IApplicationService
    {
        string GetUrl(string fileKey);

        string GetUrl(string fileKey, int width, int height);
    }
}
