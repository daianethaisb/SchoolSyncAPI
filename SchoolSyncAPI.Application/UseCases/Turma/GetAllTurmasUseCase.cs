using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Turma;

public class GetAllTurmasUseCase
{
    private readonly ITurmaRepository _repository;

    public GetAllTurmasUseCase(ITurmaRepository repository)
    {
      _repository = repository;
    }

  public async Task<IEnumerable<DomainModels.Turma>> ExecuteAsync()
    {
  return await _repository.GetAllAsync();
    }
}
