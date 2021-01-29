using System.Text.Json;
using System.Threading;
using Castle.Core.Logging;
using Moq;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Business.Test
{
    public class EventLoggerTest
    {
        private readonly EventLogger<TestDataObject> _eventLogger;
        private readonly Mock<ILogger> _logger;

        public EventLoggerTest()
        {
            _logger = new();
            _eventLogger = new(_logger.Object);
        }

        [Fact(DisplayName = "Event logger logs event to trace log.")]
        public void EventLogger_LogsEvents()
        {
            // Arrange
            TestDataObject eventData = new()
            {
                Id = "Id1"
            };

            _logger
                .SetupGet(x => x.IsTraceEnabled)
                .Returns(true);

            // Act
            _eventLogger.ConsumeAsync(eventData, CancellationToken.None);

            // Assert
            var expected = JsonSerializer.Serialize(eventData);
            _logger.Verify(x => x.Trace(expected));
        }
    }
}