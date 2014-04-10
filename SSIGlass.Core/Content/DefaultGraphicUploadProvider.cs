using System;
using System.IO;

namespace SSIGlass.Core.Content
{
    using EgaplayFx.FileStorages.Services;
    using EgaplayFx.FileStorages.Services.Net;

    public class DefaultGraphicUploadProvider : IGraphicUploadProvider
    {
        private readonly IFileCommandClient _client;

        public DefaultGraphicUploadProvider(IFileCommandClient client)
        {
            _client = client;
        }

        public string Save(string catalog, string fileName, string contentType, Stream data)
        {
            string fileKey;
            var uploadFile = new UploadFile(data, null, fileName, contentType);
            var response = _client.Save(catalog, uploadFile);
            var result = CommandResult.Create(response);
            if (result.StatusCode == StatusCodes.Success)
                fileKey = result.Results["fileKeys"];
            else
                throw new FileUploadException();

            return fileKey;
        }

        public bool Replace(string fileKey,string fileName, string contentType, Stream data)
        {
            var uploadFile = new UploadFile(data, null, fileName, contentType);
            var response = _client.Replace(fileKey, uploadFile);
            var result = CommandResult.Create(response);
            return result.StatusCode == StatusCodes.Success;
        }

        public void Delete(string fileKey)
        {
            var response = _client.Delete(fileKey);
            var result = CommandResult.Create(response);
            if (result.StatusCode != StatusCodes.Success)
            {
                throw new FileUploadException();
            }
        }
    }
}
