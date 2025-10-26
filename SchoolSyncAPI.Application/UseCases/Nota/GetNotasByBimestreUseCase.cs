using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class GetNotasByBimestreUseCase
{
 private readonly INotaRepository _repository;

    public GetNotasByBimestreUseCase(INotaRepository repository) => _repository = repository;

    public async Task<IEnumerable<DomainModels.Nota>> ExecuteAsync(int bimestre) => 
        await _repository.GetByBimestreAsync(bimestre);
}
