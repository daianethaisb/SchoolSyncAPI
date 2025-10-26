using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Disciplina.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Disciplina;

public class UpdateDisciplinaUseCase
{
    private readonly IDisciplinaRepository _repository;

    public UpdateDisciplinaUseCase(IDisciplinaRepository repository)
    {
      _repository = repository;
    }

  public async Task ExecuteAsync(UpdateDisciplinaInput input)
    {
   // Verificar se disciplina existe
   var existe = await _repository.ExistsAsync(input.IdDisciplina);
     if (!existe)
    {
      throw new InvalidOperationException("Disciplina não encontrada.");
        }

 // Validar se código já existe em outra disciplina (se fornecido)
   if (!string.IsNullOrEmpty(input.Codigo))
   {
            var existenteCodigo = await _repository.GetByCodigoAsync(input.Codigo);
       if (existenteCodigo != null && existenteCodigo.IdDisciplina != input.IdDisciplina)
  {
    throw new InvalidOperationException($"Já existe outra disciplina com o código '{input.Codigo}'.");
   }
  }

     var disciplina = new DomainModels.Disciplina
        {
   IdDisciplina = input.IdDisciplina,
      Nome = input.Nome,
   Codigo = input.Codigo,
 CargaHoraria = input.CargaHoraria,
            Descricao = input.Descricao,
  Ativo = input.Ativo
        };

   if (!disciplina.ValidarDadosObrigatorios())
        {
       throw new InvalidOperationException("Dados obrigatórios não preenchidos.");
 }

        await _repository.UpdateAsync(disciplina);
  }
}
