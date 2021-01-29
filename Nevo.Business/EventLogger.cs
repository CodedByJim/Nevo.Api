using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Coded.Core.Events;

namespace Nevo.Business
{
    /// <summary>
    ///     Logs all events.
    /// </summary>
    /// <typeparam name="TEvent">The type of the consumed event</typeparam>
    public class EventLogger<TEvent> : IConsumer<TEvent>
    {
        private readonly ILogger _logger;

        /// <summary>
        ///     Create a new event logger.
        /// </summary>
        /// <param name="logger">The logger</param>
        public EventLogger(ILogger logger) => _logger = logger;

        /// <inheritdoc />
        public Task ConsumeAsync(TEvent eventObject, CancellationToken cancellationToken)
        {
            if (_logger.IsTraceEnabled)
                _logger.Trace(JsonSerializer.Serialize(eventObject));
            return Task.CompletedTask;
        }
    }
}