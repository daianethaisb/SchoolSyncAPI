using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.Aluno;

public class DeleteAlunoUseCase
{
    private readonly IAlunoRepository _repository;
  private readonly IMatriculaRepository _matriculaRepository;

    public DeleteAlunoUseCase(
 IAlunoRepository repository,
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
     throw new InvalidOperationException("Aluno não encontrado.");
  }

  // Verificar se possui matrículas ativas
   var matriculas = await _matriculaRepository.GetByAlunoAsync(id);
        if (matriculas.Any(m => m.Situacao == "Ativa"))
 {
     throw new InvalidOperationException("Não é possível excluir aluno com matrículas ativas.");
 }

  await _repository.DeleteAsync(id);
    }
}
