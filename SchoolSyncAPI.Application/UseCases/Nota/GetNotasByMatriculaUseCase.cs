using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class GetNotasByMatriculaUseCase
{
    private readonly INotaRepository _repository;

    public GetNotasByMatriculaUseCase(INotaRepository repository) => _repository = repository;

    public async Task<IEnumerable<DomainModels.Nota>> ExecuteAsync(int idMatricula) => 
     await _repository.GetByMatriculaAsync(idMatricula);
}
