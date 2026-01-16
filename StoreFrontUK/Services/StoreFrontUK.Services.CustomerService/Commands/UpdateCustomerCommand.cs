using MediatR;
using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.Services.CustomerService.Commands;

public record UpdateCustomerCommand : IRequest
{
    public UpdateCustomerDTO? Dto { get; set; } = null;
}