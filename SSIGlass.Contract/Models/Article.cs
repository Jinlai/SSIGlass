using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Contract.Models
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class Article
    {
        /// <summary>
        /// ArticleId
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 新闻图片Key
        /// </summary>
        public string PhotoKey { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime UpdateTimestamp { get; set; }
    }
}
