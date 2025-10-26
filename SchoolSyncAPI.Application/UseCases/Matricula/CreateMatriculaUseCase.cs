using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Matricula.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Matricula;

public class CreateMatriculaUseCase
{
  private readonly IMatriculaRepository _repository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly ITurmaRepository _turmaRepository;

  public CreateMatriculaUseCase(
 IMatriculaRepository repository,
   IAlunoRepository alunoRepository,
  ITurmaRepository turmaRepository)
    {
   _repository = repository;
 _alunoRepository = alunoRepository;
   _turmaRepository = turmaRepository;
 }

  public async Task<DomainModels.Matricula> ExecuteAsync(CreateMatriculaInput input)
  {
     // Validar se aluno existe
   var alunoExiste = await _alunoRepository.ExistsAsync(input.IdAluno);
   if (!alunoExiste)
   {
 throw new InvalidOperationException("Aluno não encontrado.");
     }

  // Validar se turma existe
   var turmaExiste = await _turmaRepository.ExistsAsync(input.IdTurma);
  if (!turmaExiste)
   {
 throw new InvalidOperationException("Turma não encontrada.");
  }

  // Validar se número de matrícula já existe
      var existente = await _repository.GetByNumeroAsync(input.NumeroMatricula);
   if (existente != null)
        {
 throw new InvalidOperationException("Número de matrícula já cadastrado.");
     }

// Verificar se turma tem vagas disponíveis
var turma = await _turmaRepository.GetByIdAsync(input.IdTurma);
  if (turma != null && !turma.PossuiVagasDisponiveis())
 {
throw new InvalidOperationException("Turma sem vagas disponíveis.");
 }

        var matricula = new DomainModels.Matricula(
input.IdAluno,
  input.IdTurma,
 input.NumeroMatricula,
    input.DataMatricula,
  input.ValorMensalidade,
       input.DiaVencimento,
    input.Observacoes
 );

  // Validar dados obrigatórios
if (!matricula.ValidarDadosObrigatorios())
{
 throw new InvalidOperationException("Dados obrigatórios não preenchidos.");
     }

  return await _repository.AddAsync(matricula);
    }
}
