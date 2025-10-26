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
      throw new InvalidOperationException("Disciplina n�o encontrada.");
        }

 // Validar se c�digo j� existe em outra disciplina (se fornecido)
   if (!string.IsNullOrEmpty(input.Codigo))
   {
            var existenteCodigo = await _repository.GetByCodigoAsync(input.Codigo);
       if (existenteCodigo != null && existenteCodigo.IdDisciplina != input.IdDisciplina)
  {
    throw new InvalidOperationException($"J� existe outra disciplina com o c�digo '{input.Codigo}'.");
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
       throw new InvalidOperationException("Dados obrigat�rios n�o preenchidos.");
 }

        await _repository.UpdateAsync(disciplina);
  }
}
