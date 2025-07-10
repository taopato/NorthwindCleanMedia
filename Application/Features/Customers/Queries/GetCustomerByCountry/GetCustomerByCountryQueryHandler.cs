using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Core.Repositories;


namespace Application.Features.Customers.Queries.GetCustomerByCountry
{
    public class GetCustomerByCountryQueryHandler:IRequestHandler<GetCustomerByCountryQuery, List<GetCustomerByCountryDto>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByCountryQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<GetCustomerByCountryDto>> Handle(GetCustomerByCountryQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync(cancellationToken);

            return customers
                .Where(c => c.Country == request.Country)
                .Select(c => new GetCustomerByCountryDto
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    Country = c.Country
                }).ToList();
        }
    }
}
