using MediatR;

namespace Application.Features.Customers.Queries.GetCustomerByContactName
{
    public class GetCustomerByContactNameQuery:IRequest<List<GetCustomerByContactNameDto>>
    {
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
    }
    
    
}
