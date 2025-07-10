using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class EfSupplierRepository
        : EfRepository<Supplier>, ISupplierRepository
{
    public EfSupplierRepository(NorthwindContext ctx) : base(ctx) { }

    public Task<List<Supplier>> GetAllAsync(CancellationToken ct = default) =>
        _context.Suppliers.ToListAsync(ct);
}
