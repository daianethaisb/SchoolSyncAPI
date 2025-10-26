using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Aluno.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Aluno;

public class CreateAlunoUseCase
{
    private readonly IAlunoRepository _repository;
    private readonly IResponsavelFinanceiroRepository _responsavelRepository;

    public CreateAlunoUseCase(
        IAlunoRepository repository,
    IResponsavelFinanceiroRepository responsavelRepository)
    {
   _repository = repository;
        _responsavelRepository = responsavelRepository;
    }

    public async Task<DomainModels.Aluno> ExecuteAsync(CreateAlunoInput input)
    {
// Validar se respons�vel financeiro existe
   var responsavelExiste = await _responsavelRepository.ExistsAsync(input.IdResponsavelFinanceiro);
   if (!responsavelExiste)
  {
   throw new InvalidOperationException("Respons�vel financeiro n�o encontrado.");
  }

 // Validar se CPF j� existe (se informado)
        if (!string.IsNullOrWhiteSpace(input.Cpf))
 {
   var existente = await _repository.GetByCpfAsync(input.Cpf);
       if (existente != null)
       {
       throw new InvalidOperationException("CPF j� cadastrado.");
  }
 }

var aluno = new DomainModels.Aluno(
     input.Nome,
      input.DataNascimento,
input.Sexo,
 input.IdResponsavelFinanceiro,
   input.Cpf,
    input.Rg,
  input.Telefone,
input.Email,
 input.Cep,
    input.Logradouro,
 input.Numero,
        input.Complemento,
  input.Bairro,
      input.Cidade,
  input.Estado,
input.NecessidadesEspeciais,
       input.Observacoes
      );

    // Validar dados obrigat�rios
   if (!aluno.ValidarDadosObrigatorios())
        {
   throw new InvalidOperationException("Dados obrigat�rios n�o preenchidos.");
        }

      return await _repository.AddAsync(aluno);
    }
}
