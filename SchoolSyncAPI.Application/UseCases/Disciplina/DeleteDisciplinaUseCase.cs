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
   throw new InvalidOperationException("Disciplina não encontrada.");
  }

  // Verificar se possui vínculos com turmas
   var vinculos = await _turmaDisciplinaRepository.GetByDisciplinaAsync(id);
  if (vinculos.Any())
 {
      throw new InvalidOperationException("Não é possível excluir disciplina vinculada a turmas.");
        }

  await _repository.DeleteAsync(id);
 }
}
