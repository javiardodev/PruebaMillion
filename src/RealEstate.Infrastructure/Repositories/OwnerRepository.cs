using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities.Controller;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories;

public class OwnerRepository(ApiDbContext context) : IOwnerRepository
{
    private readonly ApiDbContext _context = context;

    public async Task<List<Owner>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Owner.ToListAsync(cancellationToken);
    }

    public async Task<int> AddItem(Owner data, CancellationToken cancellationToken)
    {
        await _context.Owner.AddAsync(data, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return data.Id;
    }
}