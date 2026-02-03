using StoreFrontUK.GlobalObjects.Common;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.CustomerService.Data;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Repository;

public interface ICustomerRepository : IRepository<CustomerDbContext, Customer, string>
{
    Task<Customer?> GetFullCustomerAsync(string id);

    Task<List<Customer>> GetAllCustomersAsync();

    Task<TableQueryOptions<Customer>> GetAllCustomersWithParamsAsync(
        List<ColumnFilterState> columnFilterState,
        PaginationState paginationState,
        List<SortingState> sortingState
    );

    Task<IEnumerable<Customer>> GetAllMisters(int totalMisters);
    Task<bool> DemonstrateIdentityResolution();
}