namespace SSIGlass.Contract.Services
{
    /// <summary>
    /// 自定义内容
    /// </summary>
    public interface ICustomContentService : IApplicationService
    {
        /// <summary>
        /// 获取内容
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="contents">内容</param>
        void Set(string key, string contents);
    }
}