using MediatR;
using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.Services.CustomerService.Commands;

public record CreateCustomerCommand : IRequest<CreateCustomerDTO>
{
    public CreateCustomerDTO? Dto { get; set; } = null;
} 

