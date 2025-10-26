using SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Domain.Interfaces;

public interface IMatriculaRepository
{
    Task<IEnumerable<Matricula>> GetAllAsync();
    Task<Matricula?> GetByIdAsync(int id);
    Task<Matricula> AddAsync(Matricula entity);
    Task UpdateAsync(Matricula entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
    // Métodos específicos
    Task<Matricula?> GetByNumeroAsync(string numeroMatricula);
    Task<IEnumerable<Matricula>> GetByAlunoAsync(int idAluno);
    Task<IEnumerable<Matricula>> GetByTurmaAsync(int idTurma);
    Task<IEnumerable<Matricula>> GetBySituacaoAsync(string situacao);
}
