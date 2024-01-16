using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using ThreeAmigos.Services.Orders.API.Controllers;
using ThreeAmigos.Services.Orders.API.Operations.AddToBasket;
using ThreeAmigos.Services.Orders.API.Operations.CompleteOrder;
using Xunit;

namespace ThreeAmigos.Services.Orders.UnitTests.ControllerTests;

public class OrdersControllerShould : TestBase
{
    private readonly ILogger<OrdersController> _logger = new NullLogger<OrdersController>();

    [Fact]
    public async Task AddToBasket_CallsMediator_ReturnsOk()
    {
        // Arrange
        const string addToBasketResult = "Item added to basket";
        MockMediator.Setup(m => m.Send(It.IsAny<AddToBasket.Command>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(addToBasketResult);

        var controller = new OrdersController(_logger, MockMediator.Object);

        // Act
        var result = await controller.AddToBasket();

        // Assert
        Assert.IsType<OkResult>(result);
        MockMediator.Verify(m => m.Send(It.IsAny<AddToBasket.Command>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CompleteOrder_CallsMediator_ReturnsOk()
    {
        // Arrange
        const string completeOrderResult = "Order completed";
        MockMediator.Setup(m => m.Send(It.IsAny<CompleteOrder.Command>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(completeOrderResult);

        var controller = new OrdersController(_logger, MockMediator.Object);

        // Act
        var result = await controller.CompleteOrder();

        // Assert
        Assert.IsType<OkResult>(result);
        MockMediator.Verify(m => m.Send(It.IsAny<CompleteOrder.Command>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public void RequireAuthorizationToAddToBasket()
    {
        // Arrange
        var controllerType = typeof(OrdersController);
        var method = controllerType.GetMethod(nameof(OrdersController.AddToBasket));

        // Act
        var attributes = method.GetCustomAttributes(typeof(AuthorizeAttribute), true);

        // Assert
        Assert.True(attributes.Any(), "No AuthorizeAttribute found on AddToBasket method");
    }

    [Fact]
    public void RequireAuthorizationToCompleteOrder()
    {
        // Arrange
        var controllerType = typeof(OrdersController);
        var method = controllerType.GetMethod(nameof(OrdersController.CompleteOrder));

        // Act
        var attributes = method.GetCustomAttributes(typeof(AuthorizeAttribute), true);

        // Assert
        Assert.True(attributes.Any(), "No AuthorizeAttribute found on CompleteOrder method");
    }
}