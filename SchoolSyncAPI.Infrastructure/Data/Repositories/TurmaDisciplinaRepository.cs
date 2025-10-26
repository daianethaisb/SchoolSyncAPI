using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Mappings;

namespace SchoolSyncAPI.Infrastructure.Data.Repositories;

public class TurmaDisciplinaRepository : ITurmaDisciplinaRepository
{
    private readonly SchoolSyncDbContext _context;

    public TurmaDisciplinaRepository(SchoolSyncDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TurmaDisciplina>> GetAllAsync()
    {
        var entities = await _context.TurmasDisciplinas
    .Include(td => td.Turma)
    .Include(td => td.Disciplina)
   .AsNoTracking()
 .ToListAsync();

        return entities.Select(TurmaDisciplinaMapping.ToDomain);
    }

    public async Task<TurmaDisciplina?> GetByIdAsync(int id)
    {
        var entity = await _context.TurmasDisciplinas
      .Include(td => td.Turma)
          .Include(td => td.Disciplina)
     .AsNoTracking()
        .FirstOrDefaultAsync(td => td.IdTurmaDisciplina == id);

        return entity != null ? TurmaDisciplinaMapping.ToDomain(entity) : null;
    }

    public async Task<TurmaDisciplina> AddAsync(TurmaDisciplina model)
    {
        var entity = TurmaDisciplinaMapping.ToEntity(model);
        _context.TurmasDisciplinas.Add(entity);
        await _context.SaveChangesAsync();
        return TurmaDisciplinaMapping.ToDomain(entity);
    }

    public async Task UpdateAsync(TurmaDisciplina model)
    {
        var entity = TurmaDisciplinaMapping.ToEntity(model);
        _context.TurmasDisciplinas.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.TurmasDisciplinas.FindAsync(id);
        if (entity != null)
        {
            _context.TurmasDisciplinas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.TurmasDisciplinas
        .AnyAsync(td => td.IdTurmaDisciplina == id);
    }

    public async Task<IEnumerable<TurmaDisciplina>> GetByTurmaAsync(int idTurma)
    {
        var entities = await _context.TurmasDisciplinas
            .Include(td => td.Turma)
            .Include(td => td.Disciplina)
                .Where(td => td.IdTurma == idTurma)
                .AsNoTracking()
                .ToListAsync();

        return entities.Select(TurmaDisciplinaMapping.ToDomain);
    }

    public async Task<IEnumerable<TurmaDisciplina>> GetByDisciplinaAsync(int idDisciplina)
    {
        var entities = await _context.TurmasDisciplinas
      .Include(td => td.Turma)
            .Include(td => td.Disciplina)
            .Where(td => td.IdDisciplina == idDisciplina)
     .AsNoTracking()
          .ToListAsync();

        return entities.Select(TurmaDisciplinaMapping.ToDomain);
    }
}
