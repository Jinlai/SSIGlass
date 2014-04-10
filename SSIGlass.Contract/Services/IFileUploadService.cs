using System.IO;

namespace SSIGlass.Contract.Services
{
    public interface IFileUploadService : IApplicationService
    {
        string Save(string fileName, string contentType, Stream data);

        void Delete(string fileKey);

        PagingResult<UploadFileItem> GetAll(int pageIndex, int pageSize);
    }
}