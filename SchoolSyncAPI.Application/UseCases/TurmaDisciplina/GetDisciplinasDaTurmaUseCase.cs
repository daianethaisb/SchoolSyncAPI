using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.TurmaDisciplina;

public class GetDisciplinasDaTurmaUseCase
{
    private readonly ITurmaDisciplinaRepository _repository;

    public GetDisciplinasDaTurmaUseCase(ITurmaDisciplinaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DomainModels.TurmaDisciplina>> ExecuteAsync(int idTurma)
    {
        return await _repository.GetByTurmaAsync(idTurma);
    }
}
