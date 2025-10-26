using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.TurmaDisciplina;

public class GetTurmasDaDisciplinaUseCase
{
    private readonly ITurmaDisciplinaRepository _repository;

    public GetTurmasDaDisciplinaUseCase(ITurmaDisciplinaRepository repository)
  {
 _repository = repository;
    }

    public async Task<IEnumerable<DomainModels.TurmaDisciplina>> ExecuteAsync(int idDisciplina)
    {
     return await _repository.GetByDisciplinaAsync(idDisciplina);
    }
}
