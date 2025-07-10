using MediatR.Pipeline;

namespace Application.Features.Customers.Queries.GetCustomerByCountry
{
    public class GetCustomerByCountryDto
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
    }
}
