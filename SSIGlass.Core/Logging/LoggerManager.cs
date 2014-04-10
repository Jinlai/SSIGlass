using System;
using System.Collections.Generic;

namespace SSIGlass.Core.Logging
{
    using Castle.Core.Logging;
    using Microsoft.Practices.ServiceLocation;

    public class LoggerManager : ILoggerManager
    {
        public const string DefaultLoggerName = "defaultApp";

        private static readonly Dictionary<string, ILogger> Loggers = new Dictionary<string, ILogger>();

        private readonly Object _syncObject = new Object();
        private readonly ILoggerFactory _factory = new NullLogFactory();

        public static ILoggerManager Current { get { return ServiceLocator.Current.GetInstance<ILoggerManager>(); } }

        public LoggerManager(ILoggerFactory factory)
        {
            _factory = factory;
        }

        public ILogger For<T>()
        {
            return GetLogger(typeof(T));
        }

        public ILogger For()
        {
            return GetLogger(DefaultLoggerName);
        }

        public ILogger For(object obj)
        {
            return GetLogger(obj.GetType());
        }

        public ILogger For(string name)
        {
            return GetLogger(name);
        }

        private ILogger GetLogger(string key)
        {
            ILogger logger;
            if (Loggers.ContainsKey(key))
            {
                logger = Loggers[key];
            }
            else
            {
                lock (_syncObject)
                {
                    if (Loggers.ContainsKey(key))
                    {
                        logger = Loggers[key];
                    }
                    else
                    {
                        logger = _factory.Create(key);
                        Loggers[key] = logger;
                    }
                }
            }
            return logger;
        }

        private ILogger GetLogger(Type type)
        {
            var key = type.FullName;
            ILogger logger;
            if (key != null && Loggers.ContainsKey(key))
            {
                logger = Loggers[key];
            }
            else
            {
                lock (_syncObject)
                {
                    if (key != null && Loggers.ContainsKey(key))
                    {
                        logger = Loggers[key];
                    }
                    else
                    {
                        logger = _factory.Create(type);
                        if (key != null) Loggers[key] = logger;
                    }
                }
            }
            return logger;
        }
    }
}