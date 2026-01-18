using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.CustomerService.Data;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Repository;

public interface ICustomerRepository : IRepository<CustomerDbContext, Customer, string>
{
    Task<Customer?> GetFullCustomerAsync(string id);

    Task<List<Customer>> GetAllCustomersAsync();
}