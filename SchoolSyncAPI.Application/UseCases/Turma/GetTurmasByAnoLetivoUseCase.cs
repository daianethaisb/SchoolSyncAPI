using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Turma;

public class GetTurmasByAnoLetivoUseCase
{
    private readonly ITurmaRepository _repository;

    public GetTurmasByAnoLetivoUseCase(ITurmaRepository repository)
    {
   _repository = repository;
    }

    public async Task<IEnumerable<DomainModels.Turma>> ExecuteAsync(int anoLetivo)
    {
return await _repository.GetByAnoLetivoAsync(anoLetivo);
 }
}
