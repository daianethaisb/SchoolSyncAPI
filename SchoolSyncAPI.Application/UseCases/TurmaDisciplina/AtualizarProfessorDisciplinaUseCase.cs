using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Application.UseCases.TurmaDisciplina.Inputs;

namespace SchoolSyncAPI.Application.UseCases.TurmaDisciplina;

public class AtualizarProfessorDisciplinaUseCase
{
    private readonly ITurmaDisciplinaRepository _repository;

  public AtualizarProfessorDisciplinaUseCase(ITurmaDisciplinaRepository repository)
{
 _repository = repository;
    }

    public async Task ExecuteAsync(AtualizarProfessorInput input)
    {
 var turmaDisciplina = await _repository.GetByIdAsync(input.IdTurmaDisciplina);
 if (turmaDisciplina == null)
      {
     throw new InvalidOperationException($"Vínculo com ID {input.IdTurmaDisciplina} não encontrado.");
  }

      turmaDisciplina.ProfessorNome = input.ProfessorNome;
 await _repository.UpdateAsync(turmaDisciplina);
    }
}
