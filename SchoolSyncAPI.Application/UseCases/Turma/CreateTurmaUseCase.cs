using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Turma.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Turma;

public class CreateTurmaUseCase
{
    private readonly ITurmaRepository _repository;

  public CreateTurmaUseCase(ITurmaRepository repository)
    {
  _repository = repository;
  }

    public async Task<DomainModels.Turma> ExecuteAsync(CreateTurmaInput input)
    {
  // Validar se j� existe turma com mesmo nome e ano letivo
   var existente = await _repository.GetByNomeAnoAsync(input.Nome, input.AnoLetivo);
  if (existente != null)
 {
    throw new InvalidOperationException("J� existe uma turma com este nome no ano letivo informado.");
        }

   var turma = new DomainModels.Turma(
  input.Nome,
   input.AnoLetivo,
  input.Serie,
     input.Turno,
  input.CapacidadeMaxima,
   input.Sala,
   input.DataInicio,
    input.DataFim
  );

  // Validar dados obrigat�rios
   if (!turma.ValidarDadosObrigatorios())
 {
       throw new InvalidOperationException("Dados obrigat�rios n�o preenchidos.");
        }

     if (!turma.ValidarTurno())
        {
     throw new InvalidOperationException("Turno inv�lido. Valores aceitos: Manh�, Tarde, Noite, Integral.");
 }

  return await _repository.AddAsync(turma);
    }
}
