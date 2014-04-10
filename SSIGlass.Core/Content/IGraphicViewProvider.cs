namespace SSIGlass.Core.Content
{
    public interface IGraphicViewProvider
    {
        string GetUrl(string fileKey);

        string GetUrl(string fileKey, int width, int height);
    }
}