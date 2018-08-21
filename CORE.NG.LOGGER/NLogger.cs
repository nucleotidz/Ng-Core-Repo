using CORE.NG.MODELS;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.NG.LOGGER
{
    public class NLogger : ILoggerService
    {
        Logger _logger;
        public NLogger()
        {
            var logFactory = NLogBuilder.ConfigureNLog("nlog.config");
            logFactory.ThrowConfigExceptions = true;
            logFactory.ThrowExceptions = true;
            logFactory.Configuration.Reload();
            _logger = LogManager.GetCurrentClassLogger(typeof(Logger));
        }

        public async Task DebugAsync(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsDebugEnabled) return;
            await Task.Run(() => _logger.Log(LogLevel.Debug, exception, format, args));
        }

        public async Task ErrorAsync(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsErrorEnabled) return;
            await Task.Run(()=>_logger.Log(LogLevel.Error,exception,format,args));
        }

        public async Task FatalAsync(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            await Task.Run(() => _logger.Log(LogLevel.Fatal, exception, format, args));
        }

        public async Task InfoAsync(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsInfoEnabled) return;
            await Task.Run(() => _logger.Log(LogLevel.Info, exception, format, args));
        }

        public async Task TraceAsync(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsTraceEnabled) return;
            await Task.Run(() => _logger.Log(LogLevel.Error, exception, format, args));
        }

        public async Task WarnAsync(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsWarnEnabled) return;
            await Task.Run(() => _logger.Log(LogLevel.Error, exception, format, args));
        }

        public async Task DebugAsync(Exception exception)
        {
            await DebugAsync(exception, string.Empty);
        }

        public async Task ErrorAsync(Exception exception)
        {
            await ErrorAsync(exception, string.Empty);
        }

        public async Task FatalAsync(Exception exception)
        {
            await this.FatalAsync(exception, string.Empty);
        }

        public async Task InfoAsync(Exception exception)
        {
            await InfoAsync(exception, string.Empty);
        }

        public async Task TraceAsync(Exception exception)
        {
            await TraceAsync(exception, string.Empty);
        }

        public async Task WarnAsync(Exception exception)
        {
            await WarnAsync(exception, string.Empty);
        }

        public async Task DebugAsync(string format, params object[] args)
        {
            await DebugAsync(null, format, args);
        }

        public async Task ErrorAsync(string format, params object[] args)
        {
            await ErrorAsync(null, format, args);
        }

        public async Task FatalAsync(string format, params object[] args)
        {
            await FatalAsync(null, format, args);
        }

        public async Task InfoAsync(string format, params object[] args)
        {
            await InfoAsync(null, format, args);
        }

        public async Task TraceAsync(string format, params object[] args)
        {
            await TraceAsync(null,format,args);
        }

        public async Task WarnAsync(string format, params object[] args)
        {
            await WarnAsync(null, format, args);
        }
    }
}
