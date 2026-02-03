using MediatR;
using StoreFrontUK.GlobalObjects.Customer;

public class GetAllMistersQuery : IRequest<IEnumerable<CustomerDTO>>
{
    public int TotalMenRequired { get; set; }
}