using System;

namespace SSIGlass.Contract
{
    public class ExtPaging
    {
        /// <summary>
        /// 排序类型
        /// </summary>
        public PagingDirection Dir { get; set; }

        /// <summary>
        /// 记录条数
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 起始记录
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }

        public string ToSortString()
        {
            return String.IsNullOrEmpty(Sort) ? string.Empty : string.Format("ORDER BY {0} {1}", Sort, Dir);
        }

        public string ToLimitString()
        {
            return string.Format("LIMIT {0},{1}", Start, Limit);
        }
    }

    public class ExtPagingResult
    {
        public object Data { get; set; }

        public int TotalRecords { get; set; }
    }

    public enum PagingDirection
    {
        ASC,
        DESC
    }
}