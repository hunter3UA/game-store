using Microsoft.Extensions.Logging;

namespace GameStore.BLL.Logger
{
    public class GlobalLogger
    {
        private readonly ILogger _logger;

        public GlobalLogger(ILogger logger)
        {
            _logger = logger;
           // _logger.LogInformation()
        }

    }
}
