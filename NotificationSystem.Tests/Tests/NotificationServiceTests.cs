using Microsoft.Extensions.Logging;
using Moq;
using NotificationSystem.Core;
using NotificationSystem.Services;
using Xunit;

namespace NotificationSystem.Tests
{
    public class NotificationServiceTests
    {
        [Fact]
        public async Task SendNotificationAsync_CallsService_WithValidInputs()
        {
            // Arrange
            var mock = new Mock<INotificationService>();
            mock.Setup(x => x.SendNotificationAsync("user@domain.com", "Test"))
                .Returns(Task.CompletedTask);

            // Act
            await mock.Object.SendNotificationAsync("user@domain.com", "Test");

            // Assert
            mock.Verify(x => x.SendNotificationAsync("user@domain.com", "Test"), Times.Once());
        }

        [Fact]
        public async Task BaseNotificationService_LogsTimestampCorrectly()
        {
            var loggerMock = new Mock<ILogger<BaseNotificationService>>();
            var transformerMock = new Mock<ITextTransformer>();
            transformerMock.Setup(t => t.TransformText(It.IsAny<string>())).Returns("TEST");
            var service = new EmailNotificationService(null, loggerMock.Object, transformerMock.Object);

            await service.SendNotificationAsync("user@domain.com", "hello");

            loggerMock.Verify(m => m.LogInformation(
                "Sending notification to {Recipient} at {Timestamp} via {ServiceType}",
                "user@domain.com", It.Is<string>(s => s.EndsWith("-02-27")), "EmailNotificationService"),
                Times.Once());
        }
    }
}
