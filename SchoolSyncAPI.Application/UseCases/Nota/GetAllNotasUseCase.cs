using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class GetAllNotasUseCase
{
    private readonly INotaRepository _repository;

    public GetAllNotasUseCase(INotaRepository repository) => _repository = repository;

    public async Task<IEnumerable<DomainModels.Nota>> ExecuteAsync() => 
        await _repository.GetAllAsync();
}
