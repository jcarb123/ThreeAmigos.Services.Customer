using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using ThreeAmigos.Services.Orders.API.Operations.CompleteOrder;
using Xunit;

namespace ThreeAmigos.Services.Orders.UnitTests.FeaturesTests.CompleteOrderTest;

public class HandlerShould : TestBase
{
    private readonly ILogger<CompleteOrder.Handler> _logger = new NullLogger<CompleteOrder.Handler>();

    [Fact]
    public async Task Handle_CallsCompleteOrder_ReturnsExpectedResult()
    {
        // Arrange
        const string expectedResponse = "Order completed";
        MockService.Setup(service => service.CompleteOrder())
            .ReturnsAsync(expectedResponse);
        
        var handler = new CompleteOrder.Handler(_logger, MockService.Object);

        // Act
        var result = await handler.Handle(new CompleteOrder.Command(), new CancellationToken());

        // Assert
        Assert.Equal(expectedResponse, result);
        MockService.Verify(service => service.CompleteOrder(), Times.Once);
    }
}