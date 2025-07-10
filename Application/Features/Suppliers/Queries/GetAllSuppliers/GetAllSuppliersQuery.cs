using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Suppliers.Queries.GetSampleSuppliers;

public record GetSampleSuppliersQuery() : IRequest<List<SupplierDto>>;
