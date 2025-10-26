using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Matricula.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Matricula;

public class UpdateMatriculaUseCase
{
  private readonly IMatriculaRepository _repository;
  private readonly IAlunoRepository _alunoRepository;
    private readonly ITurmaRepository _turmaRepository;

    public UpdateMatriculaUseCase(
   IMatriculaRepository repository,
   IAlunoRepository alunoRepository,
  ITurmaRepository turmaRepository)
    {
     _repository = repository;
     _alunoRepository = alunoRepository;
 _turmaRepository = turmaRepository;
    }

    public async Task ExecuteAsync(UpdateMatriculaInput input)
    {
  // Verificar se matr�cula existe
 var existe = await _repository.ExistsAsync(input.IdMatricula);
  if (!existe)
     {
 throw new InvalidOperationException("Matr�cula n�o encontrada.");
  }

   // Validar se aluno existe
   var alunoExiste = await _alunoRepository.ExistsAsync(input.IdAluno);
   if (!alunoExiste)
{
throw new InvalidOperationException("Aluno n�o encontrado.");
  }

        // Validar se turma existe
   var turmaExiste = await _turmaRepository.ExistsAsync(input.IdTurma);
    if (!turmaExiste)
 {
     throw new InvalidOperationException("Turma n�o encontrada.");
 }

    // Validar se n�mero de matr�cula j� existe em outro registro
   var existente = await _repository.GetByNumeroAsync(input.NumeroMatricula);
        if (existente != null && existente.IdMatricula != input.IdMatricula)
 {
    throw new InvalidOperationException("N�mero de matr�cula j� cadastrado para outra matr�cula.");
        }

        var matricula = new DomainModels.Matricula
  {
   IdMatricula = input.IdMatricula,
      IdAluno = input.IdAluno,
  IdTurma = input.IdTurma,
   DataMatricula = input.DataMatricula,
 NumeroMatricula = input.NumeroMatricula,
Situacao = input.Situacao,
   ValorMensalidade = input.ValorMensalidade,
  DiaVencimento = input.DiaVencimento,
Observacoes = input.Observacoes
  };

  if (!matricula.ValidarDadosObrigatorios())
  {
throw new InvalidOperationException("Dados obrigat�rios n�o preenchidos.");
  }

      await _repository.UpdateAsync(matricula);
    }
}
