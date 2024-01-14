using MediatR;

namespace ThreeAmigos.Services.Orders.API.Operations.AddToBasket;

public static partial class AddToBasket
{
    public class Command : IRequest<string>
    {
    }
}