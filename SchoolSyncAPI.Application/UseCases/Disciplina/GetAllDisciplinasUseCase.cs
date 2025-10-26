using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Disciplina;

public class GetAllDisciplinasUseCase
{
    private readonly IDisciplinaRepository _repository;

    public GetAllDisciplinasUseCase(IDisciplinaRepository repository)
    {
  _repository = repository;
 }

    public async Task<IEnumerable<DomainModels.Disciplina>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
