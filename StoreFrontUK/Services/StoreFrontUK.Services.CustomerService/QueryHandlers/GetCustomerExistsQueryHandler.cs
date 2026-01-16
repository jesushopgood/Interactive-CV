using MediatR;
using StoreFrontUK.Services.CustomerService.Queries;
using StoreFrontUK.Services.CustomerService.Repository;

namespace StoreFrontUK.Services.OrderService.QueryHandlers;

public class GetCustomerExistsQueryHandler : IRequestHandler<GetCustomerExistsQuery, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerExistsQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(GetCustomerExistsQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.Exists(request.CustomerId);
    }
}