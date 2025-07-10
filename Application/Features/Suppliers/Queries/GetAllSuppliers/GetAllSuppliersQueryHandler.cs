using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Core.Repositories;
using Application.Features.Suppliers.Queries.GetSampleSuppliers;

namespace Application.Features.Suppliers.Queries.GetSampleSuppliers
{
    public sealed class GetSampleSuppliersQueryHandler
        : IRequestHandler<GetSampleSuppliersQuery, List<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSampleSuppliersQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierDto>> Handle(
            GetSampleSuppliersQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _supplierRepository.GetAllAsync(cancellationToken);

            return data
                .AsEnumerable() // Burası şart!
                .Select(s => new SupplierDto
                {
                    CompanyName = s.CompanyName ?? "Unknown",
                    City = s.City ?? "N/A"
                })
                .Take(4)
                .ToList();


        }
    }
}
