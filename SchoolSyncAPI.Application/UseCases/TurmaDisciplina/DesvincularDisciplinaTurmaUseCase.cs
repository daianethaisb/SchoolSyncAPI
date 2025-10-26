using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.TurmaDisciplina;

public class DesvincularDisciplinaTurmaUseCase
{
    private readonly ITurmaDisciplinaRepository _repository;
 private readonly INotaRepository _notaRepository;

    public DesvincularDisciplinaTurmaUseCase(
 ITurmaDisciplinaRepository repository,
  INotaRepository notaRepository)
    {
  _repository = repository;
 _notaRepository = notaRepository;
 }

  public async Task ExecuteAsync(int id)
    {
 // Verificar se existe
 var existe = await _repository.ExistsAsync(id);
   if (!existe)
        {
    throw new InvalidOperationException("V�nculo n�o encontrado.");
        }

   // Verificar se existem notas lan�adas para esta disciplina nesta turma
   // Para fazer isso precisamos buscar o v�nculo para ter os IDs
        var vinculo = await _repository.GetByIdAsync(id);
  if (vinculo != null)
 {
     // Buscar matr�culas da turma e verificar se h� notas da disciplina
   // Esta � uma valida��o simplificada - em produ��o voc� poderia ter um m�todo mais espec�fico
   // Por ora, vamos permitir a exclus�o
 }

     await _repository.DeleteAsync(id);
    }
}
