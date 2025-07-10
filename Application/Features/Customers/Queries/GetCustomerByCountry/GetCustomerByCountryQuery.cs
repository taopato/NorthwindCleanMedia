using MediatR;

namespace Application.Features.Customers.Queries.GetCustomerByCountry
{
    public class GetCustomerByCountryQuery:IRequest<List<GetCustomerByCountryDto>>
    {
        public string Country { get; set; }
        public string CompanyName { get; set; }


    }
}
