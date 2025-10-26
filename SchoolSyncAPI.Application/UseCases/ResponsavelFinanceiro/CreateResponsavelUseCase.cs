using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro.Inputs;

namespace SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;

public class CreateResponsavelUseCase
{
    private readonly IResponsavelFinanceiroRepository _repository;

  public CreateResponsavelUseCase(IResponsavelFinanceiroRepository repository)
    {
     _repository = repository;
    }

public async Task<DomainModels.ResponsavelFinanceiro> ExecuteAsync(CreateResponsavelInput input)
  {
        // Validar se CPF j� existe
   var existente = await _repository.GetByCpfAsync(input.Cpf);
   if (existente != null)
   {
  throw new InvalidOperationException("CPF j� cadastrado.");
        }

    var responsavel = new DomainModels.ResponsavelFinanceiro(
   input.Nome,
       input.Cpf,
  input.Telefone,
         input.Rg,
          input.DataNascimento,
  input.Celular,
  input.Email,
      input.Cep,
   input.Logradouro,
     input.Numero,
       input.Complemento,
     input.Bairro,
         input.Cidade,
   input.Estado
 );

      // Validar dados obrigat�rios
   if (!responsavel.ValidarDadosObrigatorios())
 {
     throw new InvalidOperationException("Dados obrigat�rios n�o preenchidos.");
   }

   if (!responsavel.ValidarCpf())
    {
     throw new InvalidOperationException("CPF inv�lido.");
      }

   return await _repository.AddAsync(responsavel);
    }
}
