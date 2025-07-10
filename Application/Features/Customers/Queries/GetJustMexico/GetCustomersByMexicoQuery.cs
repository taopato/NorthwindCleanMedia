using MediatR;
using System.Collections.Generic;

namespace Application.Features.Customers.Queries.GetJustMexico
{
    public record GetCustomersByMexicoQuery : IRequest<List<CustomersByMexicoDto>>;
}
