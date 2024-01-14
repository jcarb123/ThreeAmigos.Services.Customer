using MediatR;
using ThreeAmigos.Services.Orders.API.Services;

namespace ThreeAmigos.Services.Orders.API.Operations.CompleteOrder;

public static partial class CompleteOrder
{
    public class Handler : IRequestHandler<Command, string>
    {
        private readonly ILogger<Handler> _logger;
        private readonly IOrderService _orderService;

        public Handler(ILogger<Handler> logger, IOrderService orderService)
        {
            _logger = logger ?? throw new ArgumentException("Logger not initialised", nameof(logger));
            _orderService = orderService ??
                            throw new ArgumentException("Service not initialised",
                                nameof(orderService));
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler - completing order...");
            return await _orderService.CompleteOrder();
        }
    }
}