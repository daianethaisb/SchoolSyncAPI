using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.Turma;

public class DeleteTurmaUseCase
{
    private readonly ITurmaRepository _repository;
    private readonly IMatriculaRepository _matriculaRepository;

    public DeleteTurmaUseCase(
   ITurmaRepository repository,
   IMatriculaRepository matriculaRepository)
 {
   _repository = repository;
     _matriculaRepository = matriculaRepository;
    }

  public async Task ExecuteAsync(int id)
    {
        // Verificar se existe
        var existe = await _repository.ExistsAsync(id);
   if (!existe)
   {
throw new InvalidOperationException("Turma não encontrada.");
  }

        // Verificar se possui matrículas ativas
   var matriculas = await _matriculaRepository.GetByTurmaAsync(id);
   if (matriculas.Any(m => m.Situacao == "Ativa"))
        {
    throw new InvalidOperationException("Não é possível excluir turma com matrículas ativas.");
  }

        await _repository.DeleteAsync(id);
    }
}
