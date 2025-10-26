using SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Domain.Interfaces;

public interface ITurmaDisciplinaRepository
{
  Task<IEnumerable<TurmaDisciplina>> GetAllAsync();
    Task<TurmaDisciplina?> GetByIdAsync(int id);
    Task<TurmaDisciplina> AddAsync(TurmaDisciplina entity);
    Task UpdateAsync(TurmaDisciplina entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
    // Métodos específicos
    Task<IEnumerable<TurmaDisciplina>> GetByTurmaAsync(int idTurma);
    Task<IEnumerable<TurmaDisciplina>> GetByDisciplinaAsync(int idDisciplina);
}
