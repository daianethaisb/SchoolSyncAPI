using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Matricula;

public class GetMatriculaByIdUseCase
{
    private readonly IMatriculaRepository _repository;

    public GetMatriculaByIdUseCase(IMatriculaRepository repository)
    {
        _repository = repository;
    }

    public async Task<DomainModels.Matricula?> ExecuteAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
