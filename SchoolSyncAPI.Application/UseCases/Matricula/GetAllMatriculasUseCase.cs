using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Matricula;

public class GetAllMatriculasUseCase
{
    private readonly IMatriculaRepository _repository;

    public GetAllMatriculasUseCase(IMatriculaRepository repository)
    {
  _repository = repository;
  }

 public async Task<IEnumerable<DomainModels.Matricula>> ExecuteAsync()
    {
    return await _repository.GetAllAsync();
    }
}
