// Application/Features/Customers/Queries/GetJustMexico/GetCustomersByMexicoQueryHandler.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Core.Repositories;                                // ICustomerRepository
using Application.Features.Customers.Queries.GetJustMexico;  // Query & DTO

namespace Application.Features.Customers.Queries.GetJustMexico
{
    public class GetCustomersByMexicoQueryHandler
        : IRequestHandler<GetCustomersByMexicoQuery, List<CustomersByMexicoDto>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersByMexicoQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomersByMexicoDto>> Handle(
            GetCustomersByMexicoQuery request,
            CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync(cancellationToken);

            return customers
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
