using MediatR;

namespace StoreFrontUK.Services.CustomerService.Queries;

public record GetCustomerExistsQuery : IRequest<bool>
{
    public string CustomerId { get; set; } = string.Empty;
}