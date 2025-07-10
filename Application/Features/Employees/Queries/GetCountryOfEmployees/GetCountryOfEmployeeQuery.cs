using MediatR;
using System.Collections.Generic;


namespace Application.Features.Employees.Queries.GetCountryOfEmployees
{
    public class GetCountryOfEmployeesQuery : IRequest<List<GetCountryOfEmployeeDto>>
    {
        public string Country { get; set; } = string.Empty;
    }
}
