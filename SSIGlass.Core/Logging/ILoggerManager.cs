namespace SSIGlass.Core.Logging
{
    using Castle.Core.Logging;

    public interface ILoggerManager
    {
        ILogger For<T>();

        ILogger For();

        ILogger For(object obj);

        ILogger For(string name);
    }
}