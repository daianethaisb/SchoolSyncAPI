using SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Domain.Interfaces;

public interface IAlunoRepository
{
    Task<IEnumerable<Aluno>> GetAllAsync();
    Task<Aluno?> GetByIdAsync(int id);
    Task<Aluno> AddAsync(Aluno entity);
Task UpdateAsync(Aluno entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
    // M�todos espec�ficos
    Task<Aluno?> GetByCpfAsync(string cpf);
    Task<IEnumerable<Aluno>> GetByResponsavelAsync(int idResponsavel);
    Task<IEnumerable<Aluno>> GetAtivoAsync();
}
