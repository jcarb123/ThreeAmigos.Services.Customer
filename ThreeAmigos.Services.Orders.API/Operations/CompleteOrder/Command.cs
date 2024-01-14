using MediatR;

namespace ThreeAmigos.Services.Orders.API.Operations.CompleteOrder;

public static partial class CompleteOrder
{
    public class Command : IRequest<string>
    {
    }
}