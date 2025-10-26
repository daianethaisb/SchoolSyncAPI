using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;

public class GetResponsavelByCpfUseCase
{
  private readonly IResponsavelFinanceiroRepository _repository;

    public GetResponsavelByCpfUseCase(IResponsavelFinanceiroRepository repository)
    {
     _repository = repository;
    }

    public async Task<DomainModels.ResponsavelFinanceiro?> ExecuteAsync(string cpf)
    {
  return await _repository.GetByCpfAsync(cpf);
    }
}
