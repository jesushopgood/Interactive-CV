using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Customer;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.CustomerService.Repository;

public class GetAllMistersQueryHandler : IRequestHandler<GetAllMistersQuery, IEnumerable<CustomerDTO>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetAllMistersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDTO>> Handle(GetAllMistersQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetAllMisters(request.TotalMenRequired);
        return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(result);
    }
}