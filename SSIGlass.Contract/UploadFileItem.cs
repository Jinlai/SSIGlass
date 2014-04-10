using System;

namespace SSIGlass.Contract
{
    [Serializable]
    public class UploadFileItem
    {
        public string FileKey { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public UploadFileType FileType { get; set; }
    }

    /// <summary>
    /// 文件上传类型
    /// </summary>
    public enum UploadFileType
    {
        /// <summary>
        /// 图片
        /// </summary>
        Graphic,
        /// <summary>
        /// Flash
        /// </summary>
        Flash
    }
}
