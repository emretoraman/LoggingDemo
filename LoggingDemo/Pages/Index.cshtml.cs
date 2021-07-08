using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger _logger;

        public IndexModel(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("DemoCategory");
        }

        public void OnGet()
        {
            _logger.LogInformation(LogId.LoggingDemo, "This is our first log");

            _logger.LogTrace("This is a trace log");
            _logger.LogDebug("This is a debug log");
            _logger.LogInformation("This is an information log");
            _logger.LogWarning("This is a warning log");
            _logger.LogError("This is an error log");
            _logger.LogCritical("This is a critical log");

            _logger.LogInformation("This is an information at {Time}", DateTime.UtcNow);

            try
            {
                throw new InvalidOperationException("This is invalid operation exception");
            }
            catch (Exception exception)
            {
                _logger.LogWarning(exception, "This is a warning log");
            }
        }
    }

    public class LogId
    {
        public const int LoggingDemo = 1;
    }
}
