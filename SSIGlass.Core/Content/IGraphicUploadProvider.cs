using System.IO;

namespace SSIGlass.Core.Content
{
    public interface IGraphicUploadProvider
    {
        string Save(string catalog, string fileName, string contentType, Stream data);

        bool Replace(string fileKey, string fileName, string contentType, Stream data);

        void Delete(string fileKey);
    }
}