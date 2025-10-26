using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Disciplina;

public class GetDisciplinasAtivasUseCase
{
    private readonly IDisciplinaRepository _repository;

    public GetDisciplinasAtivasUseCase(IDisciplinaRepository repository)
    {
  _repository = repository;
    }

 public async Task<IEnumerable<DomainModels.Disciplina>> ExecuteAsync()
    {
  return await _repository.GetAtivasAsync();
    }
}
