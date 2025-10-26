using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class GetNotaByIdUseCase
{
    private readonly INotaRepository _repository;

    public GetNotaByIdUseCase(INotaRepository repository) => _repository = repository;

    public async Task<DomainModels.Nota?> ExecuteAsync(int id) => 
        await _repository.GetByIdAsync(id);
}
