﻿namespace TeamCity.MSBuild.Logger
{
    using IoC;
    using Microsoft.Build.Framework;

    // ReSharper disable once UnusedMember.Global
    public class TeamCityMsBuildLogger : INodeLogger
    {
        private readonly IMutableContainer _container;
        private readonly INodeLogger _logger;

        public TeamCityMsBuildLogger()
            :this(Container.Create().Using<IoCConfiguration>())
        {
        }

        public TeamCityMsBuildLogger(IMutableContainer container)
        {
            _container = container;
            _logger = _container.Resolve<INodeLogger>();
        }

        public string Parameters
        {
            get => _logger.Parameters;
            set => _logger.Parameters = value;
        }

        public LoggerVerbosity Verbosity
        {
            get => _logger.Verbosity;
            set => _logger.Verbosity = value;
        }

        public void Initialize(IEventSource eventSource, int nodeCount)
        {
            _logger.Initialize(eventSource, nodeCount);
        }

        public void Initialize(IEventSource eventSource)
        {
            _logger.Initialize(eventSource);
        }

        public void Shutdown()
        {
            _logger.Shutdown();
            _container.Dispose();
        }
    }
}
