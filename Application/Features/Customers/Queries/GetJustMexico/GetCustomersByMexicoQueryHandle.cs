using MediatR;
using Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetJustMexico
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersByMexicoQuery, List<CustomersByMexicoDto>>
    {
        private readonly ICustomerRepository _customerRepository;


        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomersByMexicoDto>> Handle(GetCustomersByMexicoQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = await _customerRepository.GetAllAsync(cancellationToken);

            return allCustomers
                .Where(c => c.Country == "Mexico")
                .Select(c => new CustomersByMexicoDto
                {
                    ContactName = c.ContactName ?? "Unknown",
                    Country = c.Country ?? "N/A"
                })
                .Take(5)
                .ToList();
        }
    }
}

