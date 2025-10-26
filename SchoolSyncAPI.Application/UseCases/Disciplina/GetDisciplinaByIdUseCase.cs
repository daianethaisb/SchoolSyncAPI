using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Disciplina;

public class GetDisciplinaByIdUseCase
{
  private readonly IDisciplinaRepository _repository;

    public GetDisciplinaByIdUseCase(IDisciplinaRepository repository)
    {
   _repository = repository;
  }

    public async Task<DomainModels.Disciplina?> ExecuteAsync(int id)
    {
     return await _repository.GetByIdAsync(id);
 }
}
