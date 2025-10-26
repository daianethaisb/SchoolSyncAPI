using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Turma;

public class GetTurmaByIdUseCase
{
  private readonly ITurmaRepository _repository;

 public GetTurmaByIdUseCase(ITurmaRepository repository)
    {
 _repository = repository;
    }

    public async Task<DomainModels.Turma?> ExecuteAsync(int id)
  {
return await _repository.GetByIdAsync(id);
    }
}
