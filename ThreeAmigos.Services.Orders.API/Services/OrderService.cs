namespace ThreeAmigos.Services.Orders.API.Services;

public class OrderService : IOrderService
{
    private readonly ILogger<OrderService> _logger;

    public OrderService(ILogger<OrderService> logger)
    {
        _logger = logger ?? throw new ArgumentException("Logger not initialised", nameof(logger));
    }

    public async Task<string> AddToBasket()
    {
        _logger.LogInformation("Order Service - adding to basket...");
        return await Task.FromResult("Item added to basket");
    }

    public async Task<string> CompleteOrder()
    {
        _logger.LogInformation("Order Service - completing order...");
        return await Task.FromResult("Order completed");
    }
}