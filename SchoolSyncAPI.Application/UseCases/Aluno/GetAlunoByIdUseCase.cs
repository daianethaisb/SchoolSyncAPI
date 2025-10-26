using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Aluno;

public class GetAlunoByIdUseCase
{
    private readonly IAlunoRepository _repository;

    public GetAlunoByIdUseCase(IAlunoRepository repository)
  {
   _repository = repository;
  }

    public async Task<DomainModels.Aluno?> ExecuteAsync(int id)
    {
 return await _repository.GetByIdAsync(id);
    }
}
