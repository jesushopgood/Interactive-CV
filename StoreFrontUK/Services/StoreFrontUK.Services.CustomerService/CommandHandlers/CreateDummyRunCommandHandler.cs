using MediatR;
using StoreFrontUK.Services.CustomerService.Repository;

public class CreateDummyRunCommandHandler : IRequestHandler<CreateDummyRunCommand>
{
    private ICustomerRepository _customerRepository;
    public CreateDummyRunCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(CreateDummyRunCommand request, CancellationToken cancellationToken)
    {
        await _customerRepository.DemonstrateIdentityResolution();
    }
}