using MediatR;
using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.Services.CustomerService.Queries;

public record GetCustomerQuery : IRequest<CustomerDTO>
{
    public string CustomerId { get; set; } = string.Empty;
}