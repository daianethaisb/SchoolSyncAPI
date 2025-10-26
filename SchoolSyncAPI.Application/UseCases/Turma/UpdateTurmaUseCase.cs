using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Turma.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Turma;

public class UpdateTurmaUseCase
{
    private readonly ITurmaRepository _repository;

 public UpdateTurmaUseCase(ITurmaRepository repository)
 {
   _repository = repository;
 }

    public async Task ExecuteAsync(UpdateTurmaInput input)
    {
 // Verificar se turma existe
        var existe = await _repository.ExistsAsync(input.IdTurma);
  if (!existe)
    {
       throw new InvalidOperationException("Turma não encontrada.");
      }

// Validar se já existe outra turma com mesmo nome e ano letivo
  var existente = await _repository.GetByNomeAnoAsync(input.Nome, input.AnoLetivo);
  if (existente != null && existente.IdTurma != input.IdTurma)
        {
   throw new InvalidOperationException("Já existe outra turma com este nome no ano letivo informado.");
 }

    var turma = new DomainModels.Turma
   {
 IdTurma = input.IdTurma,
Nome = input.Nome,
     AnoLetivo = input.AnoLetivo,
     Serie = input.Serie,
    Turno = input.Turno,
     Sala = input.Sala,
CapacidadeMaxima = input.CapacidadeMaxima,
  DataInicio = input.DataInicio,
    DataFim = input.DataFim,
   Ativo = input.Ativo
        };

  if (!turma.ValidarDadosObrigatorios())
        {
   throw new InvalidOperationException("Dados obrigatórios não preenchidos.");
        }

  if (!turma.ValidarTurno())
        {
       throw new InvalidOperationException("Turno inválido.");
  }

  await _repository.UpdateAsync(turma);
    }
}
