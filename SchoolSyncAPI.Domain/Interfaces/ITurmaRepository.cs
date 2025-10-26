using SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Domain.Interfaces;

public interface ITurmaRepository
{
    Task<IEnumerable<Turma>> GetAllAsync();
    Task<Turma?> GetByIdAsync(int id);
 Task<Turma> AddAsync(Turma entity);
    Task UpdateAsync(Turma entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
 // Métodos específicos
    Task<IEnumerable<Turma>> GetByAnoLetivoAsync(int anoLetivo);
    Task<Turma?> GetByNomeAnoAsync(string nome, int anoLetivo);
    Task<IEnumerable<Turma>> GetAtivasAsync();
}
