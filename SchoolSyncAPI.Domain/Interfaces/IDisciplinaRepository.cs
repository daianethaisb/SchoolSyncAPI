using SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Domain.Interfaces;

public interface IDisciplinaRepository
{
    Task<IEnumerable<Disciplina>> GetAllAsync();
    Task<Disciplina?> GetByIdAsync(int id);
    Task<Disciplina> AddAsync(Disciplina entity);
    Task UpdateAsync(Disciplina entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
    // Métodos específicos
    Task<Disciplina?> GetByCodigoAsync(string codigo);
    Task<IEnumerable<Disciplina>> GetAtivasAsync();
}
