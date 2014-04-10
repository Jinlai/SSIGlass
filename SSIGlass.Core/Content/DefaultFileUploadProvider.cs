using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SSIGlass.Core.Content
{
    using EgaplayFx.FileStorages.Services;
    using EgaplayFx.FileStorages.Services.Net;
    using Contract;

    public class DefaultFileUploadProvider : IFileUploadProvider
    {
        private readonly string _fileDir;
        private readonly string _hostUrl;
        private readonly IFileCommandClient _client;

        public DefaultFileUploadProvider(string fileDir, string hostUrl, IFileCommandClient client)
        {
            _fileDir = fileDir;
            _hostUrl = hostUrl;
            _client = client;
        }

        public string Save(string fileName, string contentType, Stream data)
        {
            string fileKey;
            var uploadFile = new UploadFile(data, null, fileName, contentType);
            var response = _client.Save(_fileDir, uploadFile);
            var result = CommandResult.Create(response);
            if (result.StatusCode == StatusCodes.Success)
                fileKey = result.Results["fileKeys"];
            else
                throw new FileUploadException();

            return fileKey;
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

        public PagingResult<UploadFileItem> GetAll(int pageIndex, int pageSize)
        {
            var response = _client.GetAll(pageIndex, pageSize, _fileDir);
            var result = CommandResult.Create(response);
            var total = 0;
            var list = new List<UploadFileItem>();
            if (result.StatusCode == StatusCodes.Success)
            {
                total = int.Parse(result.Results["total"]);
                var items = result.Results["items"];
                if (!String.IsNullOrEmpty(items))
                {
                    var fileKeys = items.Split(',');
                    list.AddRange(fileKeys.Select(CreateUploadFileItem));
                }
            }
            var results = new PagingResult<UploadFileItem>(list)
                              {
                                  CurrentPage = pageIndex,
                                  PageSize = pageSize,
                                  TotalItems = total
                              };
            return results;
        }

        private UploadFileItem CreateUploadFileItem(string fileKey)
        {
            var item = new UploadFileItem();
            var extension = Path.GetExtension(fileKey);
            if (extension != null)
            {
                var ext = extension.ToLower();
                item.FileKey = fileKey;
                item.Name = Path.GetFileName(fileKey);
                item.FileType = (ext == ".jpg" || ext == ".gif" || ext == ".png" || ext == ".bmp") ? UploadFileType.Graphic : UploadFileType.Flash;
            }
            item.Url = _hostUrl + fileKey;
            return item;
        }
    }
}
