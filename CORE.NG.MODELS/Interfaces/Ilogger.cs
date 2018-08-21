using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.NG.MODELS
{
    public interface ILoggerService
    {
        Task DebugAsync(Exception exception);
        Task DebugAsync(string format, params object[] args);
        Task DebugAsync(Exception exception, string format, params object[] args);
        Task ErrorAsync(Exception exception);
        Task ErrorAsync(string format, params object[] args);
        Task ErrorAsync(Exception exception, string format, params object[] args);
        Task FatalAsync(Exception exception);
        Task FatalAsync(string format, params object[] args);
        Task FatalAsync(Exception exception, string format, params object[] args);
        Task InfoAsync(Exception exception);
        Task InfoAsync(string format, params object[] args);
        Task InfoAsync(Exception exception, string format, params object[] args);
        Task TraceAsync(Exception exception);
        Task TraceAsync(string format, params object[] args);
        Task TraceAsync(Exception exception, string format, params object[] args);
        Task WarnAsync(Exception exception);
        Task WarnAsync(string format, params object[] args);
        Task WarnAsync(Exception exception, string format, params object[] args);

    }
}
