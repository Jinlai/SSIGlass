using System.IO;

namespace SSIGlass.Core.Content
{
    using Contract;

    public interface IFileUploadProvider
    {
        string Save(string fileName, string contentType, Stream data);

        void Delete(string fileKey);

        PagingResult<UploadFileItem> GetAll(int pageIndex, int pageSize);
    }
}