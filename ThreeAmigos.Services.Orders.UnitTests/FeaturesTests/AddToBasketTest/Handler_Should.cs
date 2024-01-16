using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using ThreeAmigos.Services.Orders.API.Operations.AddToBasket;
using Xunit;

namespace ThreeAmigos.Services.Orders.UnitTests.FeaturesTests.AddToBasketTest;

public class HandlerShould : TestBase
{
    private readonly ILogger<AddToBasket.Handler> _logger = new NullLogger<AddToBasket.Handler>();

    [Fact]
    public async Task Handle_CallsAddToBasket_ReturnsExpectedResult()
    {
        // Arrange
        const string expectedResponse = "Item added to basket";
        MockService.Setup(service => service.AddToBasket())
            .ReturnsAsync(expectedResponse);
        
        var handler = new AddToBasket.Handler(_logger, MockService.Object);

        // Act
        var result = await handler.Handle(new AddToBasket.Command(), new CancellationToken());

        // Assert
        Assert.Equal(expectedResponse, result);
        MockService.Verify(service => service.AddToBasket(), Times.Once);
    }
}