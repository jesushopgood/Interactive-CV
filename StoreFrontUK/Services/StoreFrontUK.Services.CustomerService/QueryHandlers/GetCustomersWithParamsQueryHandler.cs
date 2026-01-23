using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using StoreFrontUK.GlobalObjects.Common;
using StoreFrontUK.GlobalObjects.Customer;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.CustomerService.Repository;

public class GetCustomersWithParamsQueryHandler : IRequestHandler<GetCustomersWithParamsQuery, TableQueryOptionsDTO<CustomerDTO>>
{
    private readonly IMapper _mapper;

    private readonly ICustomerRepository _repository;

    public GetCustomersWithParamsQueryHandler(IMapper mapper, ICustomerRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<TableQueryOptionsDTO<CustomerDTO>> Handle(GetCustomersWithParamsQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<TableQueryOptions<Customer>, TableQueryOptionsDTO<CustomerDTO>>(
            await _repository.GetAllCustomersWithParamsAsync(
                request.Dto.ColumnFilterState,
                request.Dto.PaginationState,
                request.Dto.SortingState));
    }
}