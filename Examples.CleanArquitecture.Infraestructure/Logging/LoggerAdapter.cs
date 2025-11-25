using Examples.CleanArquitecture.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace Examples.CleanArquitecture.Infraestructure.Logging;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class LoggerAdapter<T> : IAppLogger<T>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly ILogger<T> _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loggerFactory"></param>
    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        this._logger = loggerFactory.CreateLogger<T>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogInformation(string message, params object[] args)
    {
        this._logger.LogInformation(message, args);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public void LogWarning(string message, params object[] args)
    {
        this._logger.LogWarning(message, args);
    }
}
