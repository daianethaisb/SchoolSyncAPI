using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Mappings;

namespace SchoolSyncAPI.Infrastructure.Data.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly SchoolSyncDbContext _context;

    public AlunoRepository(SchoolSyncDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Aluno>> GetAllAsync()
    {
     var entities = await _context.Alunos
     .Include(a => a.ResponsavelFinanceiro)
        .AsNoTracking()
   .ToListAsync();

        return entities.Select(AlunoMapping.ToDomain);
    }

    public async Task<Aluno?> GetByIdAsync(int id)
    {
  var entity = await _context.Alunos
   .Include(a => a.ResponsavelFinanceiro)
      .Include(a => a.Matriculas)
     .AsNoTracking()
        .FirstOrDefaultAsync(a => a.IdAluno == id);

        return entity != null ? AlunoMapping.ToDomain(entity) : null;
    }

    public async Task<Aluno> AddAsync(Aluno model)
 {
        var entity = AlunoMapping.ToEntity(model);
_context.Alunos.Add(entity);
        await _context.SaveChangesAsync();
      return AlunoMapping.ToDomain(entity);
    }

    public async Task UpdateAsync(Aluno model)
    {
   var entity = AlunoMapping.ToEntity(model);
        _context.Alunos.Update(entity);
  await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
 {
        var entity = await _context.Alunos.FindAsync(id);
        if (entity != null)
        {
  _context.Alunos.Remove(entity);
        await _context.SaveChangesAsync();
 }
    }

    public async Task<bool> ExistsAsync(int id)
    {
  return await _context.Alunos
       .AnyAsync(a => a.IdAluno == id);
    }

    public async Task<Aluno?> GetByCpfAsync(string cpf)
    {
        var entity = await _context.Alunos
      .Include(a => a.ResponsavelFinanceiro)
   .AsNoTracking()
   .FirstOrDefaultAsync(a => a.Cpf == cpf);

        return entity != null ? AlunoMapping.ToDomain(entity) : null;
    }

    public async Task<IEnumerable<Aluno>> GetByResponsavelAsync(int idResponsavel)
 {
 var entities = await _context.Alunos
    .Include(a => a.ResponsavelFinanceiro)
 .Where(a => a.IdResponsavelFinanceiro == idResponsavel)
       .AsNoTracking()
.ToListAsync();

        return entities.Select(AlunoMapping.ToDomain);
    }

    public async Task<IEnumerable<Aluno>> GetAtivoAsync()
    {
        var entities = await _context.Alunos
 .Include(a => a.ResponsavelFinanceiro)
  .Where(a => a.Ativo)
       .AsNoTracking()
         .ToListAsync();

        return entities.Select(AlunoMapping.ToDomain);
    }
}
