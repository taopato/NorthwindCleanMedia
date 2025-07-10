using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomerByContactName
{
    public class GetCustomerByContactNameQueryHandler : IRequestHandler<GetCustomerByContactNameQuery, List<GetCustomerByContactNameDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByContactNameQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<GetCustomerByContactNameDto>> Handle(GetCustomerByContactNameQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync(cancellationToken);

            return customers
                .Where(c => c.ContactName == request.ContactName)
                .Select(c => new GetCustomerByContactNameDto
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    Country = c.Country
                }).ToList();
        }

    }

}
