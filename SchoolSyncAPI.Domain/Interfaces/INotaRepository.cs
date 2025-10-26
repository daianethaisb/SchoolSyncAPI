using SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Domain.Interfaces;

public interface INotaRepository
{
    Task<IEnumerable<Nota>> GetAllAsync();
    Task<Nota?> GetByIdAsync(int id);
  Task<Nota> AddAsync(Nota entity);
    Task UpdateAsync(Nota entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
    // Métodos específicos
    Task<IEnumerable<Nota>> GetByMatriculaAsync(int idMatricula);
    Task<IEnumerable<Nota>> GetByBimestreAsync(int bimestre);
    Task<IEnumerable<Nota>> GetByMatriculaDisciplinaAsync(int idMatricula, int idDisciplina);
}
