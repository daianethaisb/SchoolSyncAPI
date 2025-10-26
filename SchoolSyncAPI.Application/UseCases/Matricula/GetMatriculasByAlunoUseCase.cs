using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Matricula;

public class GetMatriculasByAlunoUseCase
{
    private readonly IMatriculaRepository _repository;

public GetMatriculasByAlunoUseCase(IMatriculaRepository repository)
    {
    _repository = repository;
    }

    public async Task<IEnumerable<DomainModels.Matricula>> ExecuteAsync(int idAluno)
    {
        return await _repository.GetByAlunoAsync(idAluno);
    }
}
