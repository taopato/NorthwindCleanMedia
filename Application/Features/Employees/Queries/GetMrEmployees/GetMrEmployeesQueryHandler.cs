using MediatR;
using Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
namespace Application.Features.Employees.Queries.GetMrEmployees
{
    public class GetMrEmployeesQueryHandler : IRequestHandler<GetMrEmployeesQuery, List<EmployeeMrDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetMrEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeMrDto>> Handle(GetMrEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();




            return employees
                .Where(e => e.TitleOfCourtesy == "Mr.")
                .Select(e => new EmployeeMrDto

            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,

            }).ToList();
        }

        
    }
}

