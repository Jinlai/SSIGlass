using System.IO;

namespace SSIGlass.Core.Services
{
    using Contract;
    using Contract.Services;
    using Content;

    public class FileUploadService : IFileUploadService
    {
        private readonly IFileUploadProvider _provider;

        public FileUploadService(IFileUploadProvider provider)
        {
            _provider = provider;
        }

        public string Save(string fileName, string contentType, Stream data)
        {
            return _provider.Save(fileName, contentType, data);
        }

        public void Delete(string fileKey)
        {
            _provider.Delete(fileKey);
        }

        public PagingResult<UploadFileItem> GetAll(int pageIndex, int pageSize)
        {
            return _provider.GetAll(pageIndex, pageSize);
        }
    }
}