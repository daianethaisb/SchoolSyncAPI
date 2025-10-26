using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;

public class DeleteResponsavelUseCase
{
    private readonly IResponsavelFinanceiroRepository _repository;
    private readonly IAlunoRepository _alunoRepository;

    public DeleteResponsavelUseCase(
   IResponsavelFinanceiroRepository repository,
  IAlunoRepository alunoRepository)
    {
     _repository = repository;
  _alunoRepository = alunoRepository;
    }

  public async Task ExecuteAsync(int id)
    {
        // Verificar se existe
   var existe = await _repository.ExistsAsync(id);
   if (!existe)
{
throw new InvalidOperationException("Responsável financeiro não encontrado.");
}

    // Verificar se possui alunos vinculados
   var alunos = await _alunoRepository.GetByResponsavelAsync(id);
  if (alunos.Any())
        {
      throw new InvalidOperationException("Não é possível excluir responsável com alunos vinculados.");
  }

        await _repository.DeleteAsync(id);
    }
}
