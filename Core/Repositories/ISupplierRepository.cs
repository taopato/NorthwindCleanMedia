using Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Repositories;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<List<Supplier>> GetAllAsync(CancellationToken ct = default);
}
