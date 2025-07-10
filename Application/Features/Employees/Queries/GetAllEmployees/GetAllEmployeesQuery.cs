using MediatR;
using System.Collections.Generic;

namespace Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeDto>>
    {
        public string TitleOfCourtesy { get; set; } // Kullanıcının filtrelemek için girdiği bilgi

    }
}
