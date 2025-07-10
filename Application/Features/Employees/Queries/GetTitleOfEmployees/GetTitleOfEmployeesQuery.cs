using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace Application.Features.Employees.Queries.GetTitleOfEmployees
{
    public class GetTitleOfEmployeesQuery:IRequest<List<EmployeeOfTitleDto>>
    {

    }
}
