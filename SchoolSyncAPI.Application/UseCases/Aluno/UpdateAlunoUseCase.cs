using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Aluno.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Aluno;

public class UpdateAlunoUseCase
{
    private readonly IAlunoRepository _repository;
    private readonly IResponsavelFinanceiroRepository _responsavelRepository;

    public UpdateAlunoUseCase(
   IAlunoRepository repository,
  IResponsavelFinanceiroRepository responsavelRepository)
    {
  _repository = repository;
 _responsavelRepository = responsavelRepository;
  }

    public async Task ExecuteAsync(UpdateAlunoInput input)
  {
        // Verificar se aluno existe
      var existe = await _repository.ExistsAsync(input.IdAluno);
 if (!existe)
 {
 throw new InvalidOperationException("Aluno não encontrado.");
 }

  // Validar se responsável financeiro existe
  var responsavelExiste = await _responsavelRepository.ExistsAsync(input.IdResponsavelFinanceiro);
        if (!responsavelExiste)
        {
 throw new InvalidOperationException("Responsável financeiro não encontrado.");
  }

        // Validar se CPF já existe em outro registro (se informado)
if (!string.IsNullOrWhiteSpace(input.Cpf))
  {
       var existenteCpf = await _repository.GetByCpfAsync(input.Cpf);
  if (existenteCpf != null && existenteCpf.IdAluno != input.IdAluno)
   {
    throw new InvalidOperationException("CPF já cadastrado para outro aluno.");
  }
 }

      var aluno = new DomainModels.Aluno
 {
   IdAluno = input.IdAluno,
Nome = input.Nome,
     Cpf = input.Cpf,
      Rg = input.Rg,
   DataNascimento = input.DataNascimento,
Sexo = input.Sexo,
     Telefone = input.Telefone,
     Email = input.Email,
   IdResponsavelFinanceiro = input.IdResponsavelFinanceiro,
       Cep = input.Cep,
   Logradouro = input.Logradouro,
 Numero = input.Numero,
   Complemento = input.Complemento,
   Bairro = input.Bairro,
    Cidade = input.Cidade,
Estado = input.Estado,
   NecessidadesEspeciais = input.NecessidadesEspeciais,
       Observacoes = input.Observacoes,
   Ativo = input.Ativo
        };

  if (!aluno.ValidarDadosObrigatorios())
   {
    throw new InvalidOperationException("Dados obrigatórios não preenchidos.");
        }

        await _repository.UpdateAsync(aluno);
    }
}
