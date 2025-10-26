using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Aluno;

public class GetAllAlunosUseCase
{
  private readonly IAlunoRepository _repository;

    public GetAllAlunosUseCase(IAlunoRepository repository)
  {
     _repository = repository;
    }

    public async Task<IEnumerable<DomainModels.Aluno>> ExecuteAsync()
    {
return await _repository.GetAllAsync();
 }
}
