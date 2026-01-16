using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Customer;
using StoreFrontUK.Services.CustomerService.Commands;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.CustomerService.Repository;

namespace StoreFrontUK.Services.CustomerService.CommandHandlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<CustomerDTO, Customer>(request.Dto!);
        await _customerRepository.Update(customer);
    }
}