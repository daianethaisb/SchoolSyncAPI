using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.Disciplina;

public class DeleteDisciplinaUseCase
{
    private readonly IDisciplinaRepository _repository;
    private readonly ITurmaDisciplinaRepository _turmaDisciplinaRepository;

 public DeleteDisciplinaUseCase(
   IDisciplinaRepository repository,
    ITurmaDisciplinaRepository turmaDisciplinaRepository)
    {
  _repository = repository;
 _turmaDisciplinaRepository = turmaDisciplinaRepository;
 }

  public async Task ExecuteAsync(int id)
    {
      // Verificar se existe
   var existe = await _repository.ExistsAsync(id);
        if (!existe)
   {
   throw new InvalidOperationException("Disciplina n�o encontrada.");
  }

  // Verificar se possui v�nculos com turmas
   var vinculos = await _turmaDisciplinaRepository.GetByDisciplinaAsync(id);
  if (vinculos.Any())
 {
      throw new InvalidOperationException("N�o � poss�vel excluir disciplina vinculada a turmas.");
        }

  await _repository.DeleteAsync(id);
 }
}
