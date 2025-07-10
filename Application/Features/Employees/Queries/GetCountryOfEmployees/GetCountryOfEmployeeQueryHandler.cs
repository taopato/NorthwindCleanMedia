using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using System.Threading;
using Application.Features.Employees.Queries.GetTitleOfEmployees;

namespace Application.Features.Employees.Queries.GetCountryOfEmployees
{
    public class GetCountryOfEmployeesQueryHandler :
    IRequestHandler<GetCountryOfEmployeesQuery, List<GetCountryOfEmployeeDto>> // ✅ Query sınıfı

    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public GetCountryOfEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<GetCountryOfEmployeeDto>> Handle(GetCountryOfEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees
                .Where(e => e.Country == request.Country)
                .Select(e => new GetCountryOfEmployeeDto
                {
                    FirstName = e.FirstName,
                    Country = e.Country,

                }).ToList();
        }



    }
}
