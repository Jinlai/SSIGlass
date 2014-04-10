namespace SSIGlass.Core.Services
{
    using Contract.Services;
    using EgaplayFx.Core.IO.Content;

    public class CustomContentService : ICustomContentService
    {
        private readonly IContentProvider _contentProvider;

        public CustomContentService(IContentProvider contentProvider)
        {
            _contentProvider = contentProvider;
        }

        public string Get(string key)
        {
            return _contentProvider.GetAllText(key);
        }

        public void Set(string key, string contents)
        {
            _contentProvider.SetAllText(key, contents);
        }
    }
}
