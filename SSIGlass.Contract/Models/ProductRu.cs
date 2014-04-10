using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Contract.Models
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public class ProductRu
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 所属类别Id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        public string PhotoKey { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTimestamp { get; set; }
    }
}
