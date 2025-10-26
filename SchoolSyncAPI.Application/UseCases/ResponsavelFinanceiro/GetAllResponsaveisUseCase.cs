using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;

public class GetAllResponsaveisUseCase
{
  private readonly IResponsavelFinanceiroRepository _repository;

    public GetAllResponsaveisUseCase(IResponsavelFinanceiroRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DomainModels.ResponsavelFinanceiro>> ExecuteAsync()
    {
  return await _repository.GetAllAsync();
    }
}
