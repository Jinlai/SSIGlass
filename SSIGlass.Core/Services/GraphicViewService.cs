namespace SSIGlass.Core.Services
{
    using Contract.Services;
    using Content;

    public class GraphicViewService : IGraphicViewService
    {
        private readonly IGraphicViewProvider _provider;

        public GraphicViewService(IGraphicViewProvider provider)
        {
            _provider = provider;
        }

        public string GetUrl(string fileKey)
        {
            return _provider.GetUrl(fileKey);
        }

        public string GetUrl(string fileKey, int width, int height)
        {
            return _provider.GetUrl(fileKey, width, height);
        }
    }
}