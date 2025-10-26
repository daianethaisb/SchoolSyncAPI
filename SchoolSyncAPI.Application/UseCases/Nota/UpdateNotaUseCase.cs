using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Application.UseCases.Nota.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class UpdateNotaUseCase
{
    private readonly INotaRepository _repository;

    public UpdateNotaUseCase(INotaRepository repository) => _repository = repository;

    public async Task ExecuteAsync(UpdateNotaInput input)
{
   var nota = await _repository.GetByIdAsync(input.IdNota);
 if (nota == null)
        throw new InvalidOperationException($"Nota com ID {input.IdNota} não encontrada.");

        // Validar valor da nota
        if (input.NotaValor.HasValue && (input.NotaValor < 0 || input.NotaValor > 10))
            throw new InvalidOperationException("A nota deve estar entre 0 e 10.");

        // Validar bimestre (1 a 4)
        if (input.Bimestre.HasValue && (input.Bimestre < 1 || input.Bimestre > 4))
         throw new InvalidOperationException("O bimestre deve estar entre 1 e 4.");

        // Atualizar campos
      if (input.Bimestre.HasValue)
          nota.Bimestre = input.Bimestre;
        nota.NotaValor = input.NotaValor;
        nota.Peso = input.Peso;
        nota.DataAvaliacao = input.DataAvaliacao;
        nota.Observacoes = input.Observacoes;

  await _repository.UpdateAsync(nota);
 }
}
