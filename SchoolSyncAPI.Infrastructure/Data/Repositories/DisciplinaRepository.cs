using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Mappings;

namespace SchoolSyncAPI.Infrastructure.Data.Repositories;

public class DisciplinaRepository : IDisciplinaRepository
{
    private readonly SchoolSyncDbContext _context;

    public DisciplinaRepository(SchoolSyncDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Disciplina>> GetAllAsync()
    {
        var entities = await _context.Disciplinas
        .AsNoTracking()
       .ToListAsync();

        return entities.Select(DisciplinaMapping.ToDomain);
  }

    public async Task<Disciplina?> GetByIdAsync(int id)
    {
        var entity = await _context.Disciplinas
        .Include(d => d.TurmaDisciplinas)
      .Include(d => d.Notas)
  .AsNoTracking()
  .FirstOrDefaultAsync(d => d.IdDisciplina == id);

        return entity != null ? DisciplinaMapping.ToDomain(entity) : null;
    }

    public async Task<Disciplina> AddAsync(Disciplina model)
    {
     var entity = DisciplinaMapping.ToEntity(model);
_context.Disciplinas.Add(entity);
     await _context.SaveChangesAsync();
     return DisciplinaMapping.ToDomain(entity);
    }

    public async Task UpdateAsync(Disciplina model)
    {
   var entity = DisciplinaMapping.ToEntity(model);
        _context.Disciplinas.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await _context.Disciplinas.FindAsync(id);
        if (entity != null)
     {
 _context.Disciplinas.Remove(entity);
  await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
 {
        return await _context.Disciplinas
            .AnyAsync(d => d.IdDisciplina == id);
    }

    public async Task<Disciplina?> GetByCodigoAsync(string codigo)
    {
        var entity = await _context.Disciplinas
      .AsNoTracking()
   .FirstOrDefaultAsync(d => d.Codigo == codigo);

        return entity != null ? DisciplinaMapping.ToDomain(entity) : null;
    }

    public async Task<IEnumerable<Disciplina>> GetAtivasAsync()
    {
 var entities = await _context.Disciplinas
.Where(d => d.Ativo)
   .AsNoTracking()
  .ToListAsync();

        return entities.Select(DisciplinaMapping.ToDomain);
    }
}
