using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;

public class GetResponsavelByIdUseCase
{
    private readonly IResponsavelFinanceiroRepository _repository;

    public GetResponsavelByIdUseCase(IResponsavelFinanceiroRepository repository)
  {
 _repository = repository;
    }

    public async Task<DomainModels.ResponsavelFinanceiro?> ExecuteAsync(int id)
    {
return await _repository.GetByIdAsync(id);
    }
}
