using Moq;
using NotificationSystem.Core;
using Xunit;

namespace NotificationSystem.Tests.Tests
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
    }
}
