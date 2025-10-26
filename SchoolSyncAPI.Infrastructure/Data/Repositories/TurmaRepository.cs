using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Mappings;

namespace SchoolSyncAPI.Infrastructure.Data.Repositories;

public class TurmaRepository : ITurmaRepository
{
    private readonly SchoolSyncDbContext _context;

    public TurmaRepository(SchoolSyncDbContext context)
  {
    _context = context;
    }

    public async Task<IEnumerable<Turma>> GetAllAsync()
 {
      var entities = await _context.Turmas
    .AsNoTracking()
  .ToListAsync();

        return entities.Select(TurmaMapping.ToDomain);
    }

    public async Task<Turma?> GetByIdAsync(int id)
 {
        var entity = await _context.Turmas
 .Include(t => t.Matriculas)
     .Include(t => t.TurmaDisciplinas)
     .AsNoTracking()
    .FirstOrDefaultAsync(t => t.IdTurma == id);

        return entity != null ? TurmaMapping.ToDomain(entity) : null;
    }

    public async Task<Turma> AddAsync(Turma model)
    {
        var entity = TurmaMapping.ToEntity(model);
        _context.Turmas.Add(entity);
  await _context.SaveChangesAsync();
 return TurmaMapping.ToDomain(entity);
    }

    public async Task UpdateAsync(Turma model)
    {
   var entity = TurmaMapping.ToEntity(model);
   _context.Turmas.Update(entity);
 await _context.SaveChangesAsync();
    }

  public async Task DeleteAsync(int id)
    {
        var entity = await _context.Turmas.FindAsync(id);
if (entity != null)
    {
_context.Turmas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
   return await _context.Turmas
        .AnyAsync(t => t.IdTurma == id);
    }

    public async Task<IEnumerable<Turma>> GetByAnoLetivoAsync(int anoLetivo)
    {
  var entities = await _context.Turmas
       .Where(t => t.AnoLetivo == anoLetivo)
       .AsNoTracking()
         .ToListAsync();

  return entities.Select(TurmaMapping.ToDomain);
    }

    public async Task<Turma?> GetByNomeAnoAsync(string nome, int anoLetivo)
 {
   var entity = await _context.Turmas
    .AsNoTracking()
   .FirstOrDefaultAsync(t => t.Nome == nome && t.AnoLetivo == anoLetivo);

        return entity != null ? TurmaMapping.ToDomain(entity) : null;
    }

    public async Task<IEnumerable<Turma>> GetAtivasAsync()
    {
        var entities = await _context.Turmas
            .Where(t => t.Ativo)
  .AsNoTracking()
       .ToListAsync();

        return entities.Select(TurmaMapping.ToDomain);
    }
}
