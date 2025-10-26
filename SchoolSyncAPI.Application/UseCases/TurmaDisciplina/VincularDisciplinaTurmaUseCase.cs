using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.TurmaDisciplina.Inputs;

namespace SchoolSyncAPI.Application.UseCases.TurmaDisciplina;

public class VincularDisciplinaTurmaUseCase
{
    private readonly ITurmaDisciplinaRepository _turmaDisciplinaRepository;
    private readonly ITurmaRepository _turmaRepository;
 private readonly IDisciplinaRepository _disciplinaRepository;

    public VincularDisciplinaTurmaUseCase(
        ITurmaDisciplinaRepository turmaDisciplinaRepository,
      ITurmaRepository turmaRepository,
  IDisciplinaRepository disciplinaRepository)
    {
 _turmaDisciplinaRepository = turmaDisciplinaRepository;
     _turmaRepository = turmaRepository;
      _disciplinaRepository = disciplinaRepository;
    }

    public async Task<DomainModels.TurmaDisciplina> ExecuteAsync(VincularDisciplinaTurmaInput input)
    {
        // Validar se turma existe
        var turma = await _turmaRepository.GetByIdAsync(input.IdTurma);
        if (turma == null)
        {
       throw new InvalidOperationException($"Turma com ID {input.IdTurma} não encontrada.");
        }

        // Validar se disciplina existe
   var disciplina = await _disciplinaRepository.GetByIdAsync(input.IdDisciplina);
  if (disciplina == null)
 {
throw new InvalidOperationException($"Disciplina com ID {input.IdDisciplina} não encontrada.");
   }

      // Validar se vínculo já existe
     var vinculosExistentes = await _turmaDisciplinaRepository.GetByTurmaAsync(input.IdTurma);
   if (vinculosExistentes.Any(v => v.IdDisciplina == input.IdDisciplina))
 {
     throw new InvalidOperationException($"A disciplina '{disciplina.Nome}' já está vinculada à turma '{turma.Nome}'.");
  }

   var turmaDisciplina = new DomainModels.TurmaDisciplina(
      input.IdTurma,
 input.IdDisciplina,
         input.ProfessorNome
 );

  if (!turmaDisciplina.ValidarDadosObrigatorios())
   {
       throw new InvalidOperationException("Dados obrigatórios não preenchidos.");
  }

        return await _turmaDisciplinaRepository.AddAsync(turmaDisciplina);
    }
}
