using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.CrossCutting.Common;
using RealEstate.Domain.Entities.Controller;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories;

public class OwnerRepository(ApiDbContext context) : IOwnerRepository
{
    private readonly ApiDbContext _context = context;

    public async Task<IEnumerable<Owner>> GetFilteredOwnersAsync(OwnerFilterDto filters, CancellationToken cancellationToken)
    {
        var query = _context.Owner.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filters.Name))
        {
            query = query.Where(o => o.Name.Contains(filters.Name));
        }

        if (!string.IsNullOrWhiteSpace(filters.Address))
        {
            query = query.Where(o => o.Address.Contains(filters.Address));
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> AddItem(Owner data, CancellationToken cancellationToken)
    {
        await _context.Owner.AddAsync(data, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return data.Id;
    }
}