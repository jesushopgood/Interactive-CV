using AutoMapper;
using MediatR;
using StoreFrontUK.Services.CustomerService.Commands;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.CustomerService.Repository;
using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.Services.CustomerService.CommandHandlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDTO>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CreateCustomerDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<CreateCustomerDTO, Customer>(request.Dto!);
        var createdEntity = await _customerRepository.Create(customer);
        return _mapper.Map<CreateCustomerDTO>(createdEntity);
    }
}