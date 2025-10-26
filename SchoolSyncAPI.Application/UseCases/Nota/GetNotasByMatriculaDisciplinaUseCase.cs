using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class GetNotasByMatriculaDisciplinaUseCase
{
    private readonly INotaRepository _repository;

    public GetNotasByMatriculaDisciplinaUseCase(INotaRepository repository) => _repository = repository;

    public async Task<IEnumerable<DomainModels.Nota>> ExecuteAsync(int idMatricula, int idDisciplina) => 
      await _repository.GetByMatriculaDisciplinaAsync(idMatricula, idDisciplina);
}
