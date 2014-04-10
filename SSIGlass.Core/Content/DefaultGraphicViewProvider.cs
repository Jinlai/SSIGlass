using System;

namespace SSIGlass.Core.Content
{
    public class DefaultGraphicViewProvider : IGraphicViewProvider
    {
        private readonly string _hostUrl;
        private readonly string _graphicUrl;

        public DefaultGraphicViewProvider(string hostUrl, string graphicUrl)
        {
            _hostUrl = hostUrl;
            _graphicUrl = graphicUrl;
        }

        public string GetUrl(string fileKey)
        {
            return _hostUrl + fileKey;
        }

        public string GetUrl(string fileKey, int width, int height)
        {
            return String.Format("{0}?fileKey={1}&w={2}&h={3}", _graphicUrl, fileKey, width, height);
        }
    }
}