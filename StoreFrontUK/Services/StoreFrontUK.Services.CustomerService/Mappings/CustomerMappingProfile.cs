using AutoMapper;
using StoreFrontUK.GlobalObjects.Customer;
using StoreFrontUK.Services.CustomerService.Entities;

namespace StoreFrontUK.Services.CustomerService.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerContactDTO, CustomerContact>().ReverseMap();
        CreateMap<CustomerAddressDTO, CustomerAddress>().ReverseMap();
        CreateMap<CustomerNoteDTO, CustomerNote>().ReverseMap();
        CreateMap<CustomerDTO, Customer>().ReverseMap();
        CreateMap<CreateCustomerDTO, Customer>().ReverseMap();
    }
}