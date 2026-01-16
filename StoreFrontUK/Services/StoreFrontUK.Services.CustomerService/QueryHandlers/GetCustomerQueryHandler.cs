using AutoMapper;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.CustomerService.Queries;
using MediatR;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.CustomerService.Repository;
using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.Services.CustomerService.QueryHandlers;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
{
    private IMapper _mapper;
    private ICustomerRepository _customerRepository;
    public GetCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetFullCustomer(request.CustomerId);
        
        if (result is null)
            throw new NotFoundException($"Customer {request.CustomerId} is not found.");

        return await Task.FromResult(_mapper.Map<Customer, CustomerDTO>(result));        
    }
}