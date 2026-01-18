using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Customer;
using StoreFrontUK.Services.CustomerService.Queries;
using StoreFrontUK.Services.CustomerService.Repository;

namespace StoreFrontUK.Services.CustomerService.QueryHandlers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDTO>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetAllCustomersAsync();
        return _mapper.Map<List<CustomerDTO>>(result);
    }
}