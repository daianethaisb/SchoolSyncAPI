using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Mappings;

namespace SchoolSyncAPI.Infrastructure.Data.Repositories;

public class ResponsavelFinanceiroRepository : IResponsavelFinanceiroRepository
{
    private readonly SchoolSyncDbContext _context;

    public ResponsavelFinanceiroRepository(SchoolSyncDbContext context)
    {
  _context = context;
    }

    public async Task<IEnumerable<ResponsavelFinanceiro>> GetAllAsync()
 {
        var entities = await _context.ResponsaveisFinanceiros
  .AsNoTracking()
         .ToListAsync();
     return entities.Select(ResponsavelFinanceiroMapping.ToDomain);
    }

    public async Task<ResponsavelFinanceiro?> GetByIdAsync(int id)
    {
     var entity = await _context.ResponsaveisFinanceiros
    .Include(r => r.Alunos)
       .AsNoTracking()
            .FirstOrDefaultAsync(r => r.IdResponsavel == id);

        return entity != null ? ResponsavelFinanceiroMapping.ToDomain(entity) : null;
    }

    public async Task<ResponsavelFinanceiro> AddAsync(ResponsavelFinanceiro model)
    {
        var entity = ResponsavelFinanceiroMapping.ToEntity(model);
_context.ResponsaveisFinanceiros.Add(entity);
 await _context.SaveChangesAsync();
        return ResponsavelFinanceiroMapping.ToDomain(entity);
    }

    public async Task UpdateAsync(ResponsavelFinanceiro model)
  {
        var entity = ResponsavelFinanceiroMapping.ToEntity(model);
        _context.ResponsaveisFinanceiros.Update(entity);
    await _context.SaveChangesAsync();
  }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.ResponsaveisFinanceiros.FindAsync(id);
        if (entity != null)
 {
    _context.ResponsaveisFinanceiros.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.ResponsaveisFinanceiros
            .AnyAsync(r => r.IdResponsavel == id);
    }

    public async Task<ResponsavelFinanceiro?> GetByCpfAsync(string cpf)
    {
        var entity = await _context.ResponsaveisFinanceiros
   .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Cpf == cpf);

        return entity != null ? ResponsavelFinanceiroMapping.ToDomain(entity) : null;
    }

    public async Task<IEnumerable<ResponsavelFinanceiro>> GetAtivoAsync()
    {
        var entities = await _context.ResponsaveisFinanceiros
         .Where(r => r.Ativo)
     .AsNoTracking()
      .ToListAsync();

  return entities.Select(ResponsavelFinanceiroMapping.ToDomain);
    }
}
