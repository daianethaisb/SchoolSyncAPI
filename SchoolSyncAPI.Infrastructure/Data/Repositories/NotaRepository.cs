using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Mappings;

namespace SchoolSyncAPI.Infrastructure.Data.Repositories;

public class NotaRepository : INotaRepository
{
    private readonly SchoolSyncDbContext _context;

    public NotaRepository(SchoolSyncDbContext context)
    {
      _context = context;
  }

    public async Task<IEnumerable<Nota>> GetAllAsync()
    {
        var entities = await _context.Notas
  .Include(n => n.Matricula)
       .ThenInclude(m => m.Aluno)
   .Include(n => n.Disciplina)
  .AsNoTracking()
            .ToListAsync();

        return entities.Select(NotaMapping.ToDomain);
    }

    public async Task<Nota?> GetByIdAsync(int id)
    {
        var entity = await _context.Notas
   .Include(n => n.Matricula)
                .ThenInclude(m => m.Aluno)
   .Include(n => n.Disciplina)
  .AsNoTracking()
  .FirstOrDefaultAsync(n => n.IdNota == id);

        return entity != null ? NotaMapping.ToDomain(entity) : null;
    }

    public async Task<Nota> AddAsync(Nota model)
    {
   var entity = NotaMapping.ToEntity(model);
      _context.Notas.Add(entity);
     await _context.SaveChangesAsync();
     return NotaMapping.ToDomain(entity);
    }

    public async Task UpdateAsync(Nota model)
    {
  var entity = NotaMapping.ToEntity(model);
     _context.Notas.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
   var entity = await _context.Notas.FindAsync(id);
        if (entity != null)
   {
     _context.Notas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Notas
 .AnyAsync(n => n.IdNota == id);
  }

    public async Task<IEnumerable<Nota>> GetByMatriculaAsync(int idMatricula)
    {
  var entities = await _context.Notas
  .Include(n => n.Matricula)
.ThenInclude(m => m.Aluno)
       .Include(n => n.Disciplina)
     .Where(n => n.IdMatricula == idMatricula)
 .AsNoTracking()
    .ToListAsync();

 return entities.Select(NotaMapping.ToDomain);
    }

    public async Task<IEnumerable<Nota>> GetByBimestreAsync(int bimestre)
    {
     var entities = await _context.Notas
  .Include(n => n.Matricula)
.ThenInclude(m => m.Aluno)
   .Include(n => n.Disciplina)
  .Where(n => n.Bimestre == bimestre)
   .AsNoTracking()
     .ToListAsync();

    return entities.Select(NotaMapping.ToDomain);
 }

    public async Task<IEnumerable<Nota>> GetByMatriculaDisciplinaAsync(int idMatricula, int idDisciplina)
    {
   var entities = await _context.Notas
 .Include(n => n.Matricula)
.ThenInclude(m => m.Aluno)
      .Include(n => n.Disciplina)
 .Where(n => n.IdMatricula == idMatricula && n.IdDisciplina == idDisciplina)
    .AsNoTracking()
      .ToListAsync();

   return entities.Select(NotaMapping.ToDomain);
    }
}
