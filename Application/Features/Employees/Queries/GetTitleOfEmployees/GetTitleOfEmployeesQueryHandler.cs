using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Core.Repositories;
using System.Threading;


namespace Application.Features.Employees.Queries.GetTitleOfEmployees
{
    public class GetTitleOfEmployeesQueryHandler:IRequestHandler<GetTitleOfEmployeesQuery, List<EmployeeOfTitleDto>>

    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public GetTitleOfEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeOfTitleDto>> Handle(GetTitleOfEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees
                .Where(e => e.Title == "Sales Representative")
                .Select(e => new EmployeeOfTitleDto
                {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Title = e.Title,

                }).ToList();
        }
    }
}
