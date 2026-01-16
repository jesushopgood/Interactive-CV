using MediatR;
using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.Services.CustomerService.Queries;

public record GetAllCustomersQuery : IRequest<IEnumerable<CustomerDTO>> { }