using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Disciplina.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Disciplina;

public class CreateDisciplinaUseCase
{
    private readonly IDisciplinaRepository _repository;

    public CreateDisciplinaUseCase(IDisciplinaRepository repository)
    {
   _repository = repository;
}

    public async Task<DomainModels.Disciplina> ExecuteAsync(CreateDisciplinaInput input)
    {
        // Validar se código já existe (se fornecido)
        if (!string.IsNullOrEmpty(input.Codigo))
        {
     var existente = await _repository.GetByCodigoAsync(input.Codigo);
    if (existente != null)
            {
 throw new InvalidOperationException($"Já existe uma disciplina com o código '{input.Codigo}'.");
     }
}

        var disciplina = new DomainModels.Disciplina(
       input.Nome,
  input.Codigo,
input.CargaHoraria,
       input.Descricao
        );

 // Validar dados obrigatórios
        if (!disciplina.ValidarDadosObrigatorios())
        {
       throw new InvalidOperationException("Dados obrigatórios não preenchidos.");
  }

      return await _repository.AddAsync(disciplina);
  }
}
