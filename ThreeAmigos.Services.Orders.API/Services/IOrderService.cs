namespace ThreeAmigos.Services.Orders.API.Services;

public interface IOrderService
{
    public Task<string> AddToBasket();
    public Task<string> CompleteOrder();
}