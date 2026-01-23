using MediatR;
using StoreFrontUK.GlobalObjects.Common;
using StoreFrontUK.GlobalObjects.Customer;

public record GetCustomersWithParamsQuery : IRequest<TableQueryOptionsDTO<CustomerDTO>>
{
    public GetCustomersWithFiltersDTO Dto { get; set; } = new();
}