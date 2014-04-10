namespace SSIGlass.Web.Areas.Admin.ViewModels
{
    public class PagingViewModel
    {
        /// <summary>
        /// 排序类型
        /// </summary>
        public PagingDirection Direction { get; set; }

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
    }

    public class PagingResultViewModel
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