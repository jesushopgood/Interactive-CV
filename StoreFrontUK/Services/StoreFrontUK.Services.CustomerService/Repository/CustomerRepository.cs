using StoreFrontUK.Services.CustomerService.Data;
using StoreFrontUK.Services.CustomerService.Entities;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.CustomerService.Repository;

public class CustomerRepository : Repository<CustomerDbContext, Customer, string>, ICustomerRepository
{
    public CustomerRepository(CustomerDbContext context) : base(context)
    {
    }

    public async Task<Customer> GetFullCustomer(string id)
    {
        var result = _context.Set<Customer>()
                            .Include(c => c.Addresses)
                            .Include(c => c.CustomerContacts)
                            .Include(c => c.CustomerNotes)
                            .Single(c => c.CustomerId == id);
        return await Task.FromResult(result);
    }
}