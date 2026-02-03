using StoreFrontUK.Services.CustomerService.Data;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.Common.Repository;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.GlobalObjects.Common;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StoreFrontUK.Services.Common.Exceptions;
using System.Data.Common;

namespace StoreFrontUK.Services.CustomerService.Repository;

public class Names
{
    public string FirstName { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
}

public class CustomerRepository : Repository<CustomerDbContext, Customer, string>, ICustomerRepository
{
    private string[] _validColumns = ["customerName.title", "customerName.firstName", "customerName.surname", "customerEmailAddress"];

    public CustomerRepository(CustomerDbContext context) : base(context) { }

    public async Task<Customer?> GetFullCustomerAsync(string id) =>
        await GetByIdAsync(id, c => c.CustomerId,
                            c => c.Addresses,
                            c => c.CustomerNotes,
                            c => c.CustomerContacts);

    public async Task<List<Customer>> GetAllCustomersAsync() =>
        await GetAllAsync(c => c.Addresses,
                            c => c.CustomerNotes,
                            c => c.CustomerContacts);

    public async Task<List<Customer>> GetAllCustomersWithParamsAsync() =>
        await GetAllAsync(c => c.Addresses,
                            c => c.CustomerNotes,
                            c => c.CustomerContacts);

    public async Task<TableQueryOptions<Customer>> GetAllCustomersWithParamsAsync(
                                                            List<ColumnFilterState> columnFilterState,
                                                            PaginationState paginationState,
                                                            List<SortingState> sortingState)
    {
        IQueryable<Customer> query = _context.Customers;

        foreach (var filter in columnFilterState)
        {
            var id = filter.Id.Replace("_", ".");
            if (!_validColumns.Contains(id)) throw new InvalidDataException("Invalid Column Name");
            query = query.Where($"{id}.startsWith(@0)", filter.Value);
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

    public override async Task Update(Customer entity)
    {
        var entityKey = entity.GetKey();
        var entityToUpdate = _context.Set<Customer>().Find(entityKey);

        if (entityToUpdate is null)
            throw new NotFoundException($"The Customer {entityKey} is not found");

        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
        var ownedEntry = _context.Entry(entityToUpdate).Reference(e => e.CustomerName).TargetEntry;
        ownedEntry?.CurrentValues.SetValues(entity.CustomerName);
        await _context.SaveChangesAsync();
    }

    #region Learning Section

    public async Task<IEnumerable<Customer>> GetAllMisters(int totalMisters)
    {
        ParameterExpression param = Expression.Parameter(typeof(Customer), "c");
        MemberExpression titleProperty = Expression.Property(param, "CustomerTitle");
        ConstantExpression constMr = Expression.Constant("Mr");
        BinaryExpression equal = Expression.Equal(titleProperty, constMr);

        Expression<Func<Customer, bool>> lambda = Expression.Lambda<Func<Customer, bool>>(equal, param);

        var query = _context.Customers.Where(lambda).Take(totalMisters);
        return await query.ToListAsync();
    }

    public async Task<bool> DemonstrateIdentityResolution()
    {
        var customer1 = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerName.FirstName == "Nikola") ?? new Customer();
        var customer2 = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerName.Surname == "Tesla") ?? new Customer();

        customer1.LoyaltyPoints = 1000;
        return customer1.LoyaltyPoints == customer2.LoyaltyPoints;
    }

    #endregion
}
