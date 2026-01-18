using StoreFrontUK.Services.CustomerService.Data;
using StoreFrontUK.Services.CustomerService.Entities;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.CustomerService.Repository;

public class CustomerRepository : Repository<CustomerDbContext, Customer, string>, ICustomerRepository
{
    public CustomerRepository(CustomerDbContext context) : base(context)
    {
    }

    public async Task<Customer?> GetFullCustomerAsync(string id) =>
        await GetByIdAsync(id, c => c.CustomerId, c => c.Addresses, c => c.CustomerNotes, c => c.CustomerContacts);

    public async Task<List<Customer>> GetAllCustomersAsync() =>
        await GetAllAsync(c => c.Addresses, c => c.CustomerNotes, c => c.CustomerContacts);

}