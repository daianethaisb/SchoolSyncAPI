using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Disciplina;

public class GetDisciplinaByCodigoUseCase
{
    private readonly IDisciplinaRepository _repository;

    public GetDisciplinaByCodigoUseCase(IDisciplinaRepository repository)
    {
        _repository = repository;
    }

    public async Task<DomainModels.Disciplina?> ExecuteAsync(string codigo)
    {
   return await _repository.GetByCodigoAsync(codigo);
    }
}
