using MediatR;
using Moq;
using ThreeAmigos.Services.Orders.API.Services;

namespace ThreeAmigos.Services.Orders.UnitTests;

public class TestBase
{
    protected readonly Mock<IMediator> MockMediator;
    protected readonly Mock<IOrderService> MockService;

    protected TestBase()
    {
        MockMediator = new Mock<IMediator>();
        MockService = new Mock<IOrderService>();
    }
}