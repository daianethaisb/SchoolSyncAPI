using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Mappings;

namespace SchoolSyncAPI.Infrastructure.Data.Repositories;

public class MatriculaRepository : IMatriculaRepository
{
    private readonly SchoolSyncDbContext _context;

    public MatriculaRepository(SchoolSyncDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Matricula>> GetAllAsync()
    {
    var entities = await _context.Matriculas
            .Include(m => m.Aluno)
  .Include(m => m.Turma)
    .AsNoTracking()
   .ToListAsync();

        return entities.Select(MatriculaMapping.ToDomain);
 }

    public async Task<Matricula?> GetByIdAsync(int id)
    {
var entity = await _context.Matriculas
       .Include(m => m.Aluno)
   .Include(m => m.Turma)
   .Include(m => m.Notas)
  .AsNoTracking()
       .FirstOrDefaultAsync(m => m.IdMatricula == id);

        return entity != null ? MatriculaMapping.ToDomain(entity) : null;
    }

    public async Task<Matricula> AddAsync(Matricula model)
 {
      var entity = MatriculaMapping.ToEntity(model);
      _context.Matriculas.Add(entity);
   await _context.SaveChangesAsync();
        return MatriculaMapping.ToDomain(entity);
    }

 public async Task UpdateAsync(Matricula model)
    {
  var entity = MatriculaMapping.ToEntity(model);
 _context.Matriculas.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Matriculas.FindAsync(id);
  if (entity != null)
        {
            _context.Matriculas.Remove(entity);
  await _context.SaveChangesAsync();
  }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Matriculas
        .AnyAsync(m => m.IdMatricula == id);
    }

    public async Task<Matricula?> GetByNumeroAsync(string numeroMatricula)
    {
var entity = await _context.Matriculas
 .Include(m => m.Aluno)
         .Include(m => m.Turma)
  .AsNoTracking()
   .FirstOrDefaultAsync(m => m.NumeroMatricula == numeroMatricula);

        return entity != null ? MatriculaMapping.ToDomain(entity) : null;
    }

    public async Task<IEnumerable<Matricula>> GetByAlunoAsync(int idAluno)
    {
        var entities = await _context.Matriculas
       .Include(m => m.Aluno)
   .Include(m => m.Turma)
     .Where(m => m.IdAluno == idAluno)
       .AsNoTracking()
      .ToListAsync();

        return entities.Select(MatriculaMapping.ToDomain);
 }

    public async Task<IEnumerable<Matricula>> GetByTurmaAsync(int idTurma)
    {
   var entities = await _context.Matriculas
            .Include(m => m.Aluno)
   .Include(m => m.Turma)
  .Where(m => m.IdTurma == idTurma)
  .AsNoTracking()
            .ToListAsync();

        return entities.Select(MatriculaMapping.ToDomain);
    }

    public async Task<IEnumerable<Matricula>> GetBySituacaoAsync(string situacao)
    {
     var entities = await _context.Matriculas
       .Include(m => m.Aluno)
  .Include(m => m.Turma)
.Where(m => m.Situacao == situacao)
       .AsNoTracking()
.ToListAsync();

      return entities.Select(MatriculaMapping.ToDomain);
    }
}
