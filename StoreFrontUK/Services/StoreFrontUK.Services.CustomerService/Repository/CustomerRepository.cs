using StoreFrontUK.Services.CustomerService.Data;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.Common.Repository;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.GlobalObjects.Common;

namespace StoreFrontUK.Services.CustomerService.Repository;

public class CustomerRepository : Repository<CustomerDbContext, Customer, string>, ICustomerRepository
{
    private string[] _validColumns = ["customerTitle", "customerFirstName", "customerSurname", "customerEmailAddress"];

    public CustomerRepository(CustomerDbContext context) : base(context) { }

    public async Task<Customer?> GetFullCustomerAsync(string id) =>
        await GetByIdAsync(id, c => c.CustomerId, c => c.Addresses, c => c.CustomerNotes, c => c.CustomerContacts);

    public async Task<List<Customer>> GetAllCustomersAsync() =>
        await GetAllAsync(c => c.Addresses, c => c.CustomerNotes, c => c.CustomerContacts);

    public async Task<List<Customer>> GetAllCustomersWithParamsAsync() =>
        await GetAllAsync(c => c.Addresses, c => c.CustomerNotes, c => c.CustomerContacts);

    public async Task<TableQueryOptions<Customer>> GetAllCustomersWithParamsAsync(
                                                            List<ColumnFilterState> columnFilterState,
                                                            PaginationState paginationState,
                                                            List<SortingState> sortingState)
    {
        IQueryable<Customer> query = _context.Customers;

        foreach (var filter in columnFilterState)
        {
            if (!_validColumns.Contains(filter.Id)) throw new InvalidDataException("Invalid Column Name");
            query = query.Where($"{filter.Id}.startsWith(@0)", filter.Value);
        }

        if (sortingState.Any())
        {
            var sortString = string.Join(", ", sortingState.Select(s => $"{s.Id} {(s.Desc ? "desc" : "asc")}"));
            query = query.OrderBy(sortString);
        }

        var totalRowCount = await query.CountAsync();

        query = query
            .Skip(paginationState.PageSize * paginationState.PageIndex)
            .Take(paginationState.PageSize);

        query = await AppendIncludesAsync(query, c => c.Addresses, c => c.CustomerContacts, c => c.CustomerNotes);

        return new TableQueryOptions<Customer>
        {
            EntityList = await query.ToListAsync(),
            TotalRowCount = totalRowCount
        };
    }
}
