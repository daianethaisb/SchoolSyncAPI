using SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Domain.Interfaces;

public interface IResponsavelFinanceiroRepository
{
    Task<IEnumerable<ResponsavelFinanceiro>> GetAllAsync();
    Task<ResponsavelFinanceiro?> GetByIdAsync(int id);
    Task<ResponsavelFinanceiro> AddAsync(ResponsavelFinanceiro entity);
    Task UpdateAsync(ResponsavelFinanceiro entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    
    // Métodos específicos
    Task<ResponsavelFinanceiro?> GetByCpfAsync(string cpf);
    Task<IEnumerable<ResponsavelFinanceiro>> GetAtivoAsync();
}
