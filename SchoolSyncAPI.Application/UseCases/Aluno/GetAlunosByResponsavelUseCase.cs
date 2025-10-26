using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Aluno;

public class GetAlunosByResponsavelUseCase
{
    private readonly IAlunoRepository _repository;

    public GetAlunosByResponsavelUseCase(IAlunoRepository repository)
{
  _repository = repository;
  }

    public async Task<IEnumerable<DomainModels.Aluno>> ExecuteAsync(int idResponsavel)
    {
        return await _repository.GetByResponsavelAsync(idResponsavel);
    }
}
