using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class DeleteNotaUseCase
{
    private readonly INotaRepository _repository;

    public DeleteNotaUseCase(INotaRepository repository) => _repository = repository;

    public async Task ExecuteAsync(int id)
    {
   var nota = await _repository.GetByIdAsync(id);
        if (nota == null)
   throw new InvalidOperationException($"Nota com ID {id} não encontrada.");

   await _repository.DeleteAsync(id);
    }
}
