using StoreFrontUK.GlobalObjects.Customer.Enums;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Data;

public static class CustomerSeeder
{
    public static void Seed(CustomerDbContext context)
    {
        var customer1 = new Customer { CustomerId = "1AA", CustomerName = "PLH Industries", CustomerEmailAddress = "abc@123.com", LoyaltyPoints = 2 };
        var customer2 = new Customer { CustomerId = "2AA", CustomerName = "Pedromatics", LoyaltyPoints = 2, CustomerEmailAddress = "def@345.com" };
        var customer3 = new Customer { CustomerId = "3AA", CustomerName = "Job Healing Inc.", LoyaltyPoints = 10, CustomerEmailAddress = "ghi@678.com" };
            
        if (!context.Customers.Any())
        {
            context.Customers.AddRange(customer1, customer2, customer3);
        }
        
        if (!context.CustomerAddresses.Any())
        {
            context.CustomerAddresses.AddRange(
                new CustomerAddress { Customer = customer1, AddressType = AddressType.Billing, Line1 = "1a Billigham St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
                new CustomerAddress { Customer = customer1, AddressType = AddressType.Delivery, Line1 = "1a Delivery St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
                new CustomerAddress { Customer = customer1, AddressType = AddressType.Secondary, Line1 = "1a Second St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
                new CustomerAddress { Customer = customer2, AddressType = AddressType.Billing, Line1 = "2a Billing St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
                new CustomerAddress { Customer = customer2, AddressType = AddressType.Delivery, Line1 = "2a Delina St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
                new CustomerAddress { Customer = customer3, AddressType = AddressType.Delivery, Line1 = "3a Delva St.", Line2 = "Liverpool", Postcode = "L1 4AA" },
                new CustomerAddress { Customer = customer3, AddressType = AddressType.Billing, Line1 = "3a Billy St.", Line2 = "Liverpool", Postcode = "L1 4AA" }
            );
        }

        if (!context.CustomerContacts.Any())
        {
            context.CustomerContacts.AddRange(
                new CustomerContact { Customer = customer1, CustomerContactType = CustomerContactType.Email, Value = "aa1@aa.com"},
                new CustomerContact { Customer = customer1, CustomerContactType = CustomerContactType.Mobile, Value = "09898112112"},
                new CustomerContact { Customer = customer2, CustomerContactType = CustomerContactType.Email, Value = "aa2@aa.com"},
                new CustomerContact { Customer = customer3, CustomerContactType = CustomerContactType.Email, Value = "aa3@aa.com"}
            );
        }

        if (!context.CustomerNotes.Any())
        {
            context.CustomerNotes.AddRange(
                new CustomerNote { Customer = customer1, Message = "My package was late" },
                new CustomerNote { Customer = customer1, Message = "My dog ate the package" },
                new CustomerNote { Customer = customer3, Message = "I will be out on Tuesday" },
                new CustomerNote { Customer = customer3, Message = "Why have you sent me incotenance pads?" }
            );    
        }

        context.SaveChanges();
    }
}