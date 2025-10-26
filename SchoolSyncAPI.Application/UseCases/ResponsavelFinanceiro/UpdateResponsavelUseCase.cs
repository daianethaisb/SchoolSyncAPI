using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro.Inputs;

namespace SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;

public class UpdateResponsavelUseCase
{
    private readonly IResponsavelFinanceiroRepository _repository;

    public UpdateResponsavelUseCase(IResponsavelFinanceiroRepository repository)
 {
        _repository = repository;
    }

 public async Task ExecuteAsync(UpdateResponsavelInput input)
    {
// Verificar se existe
        var existe = await _repository.ExistsAsync(input.IdResponsavel);
  if (!existe)
   {
     throw new InvalidOperationException("Respons�vel financeiro n�o encontrado.");
        }

  // Validar se CPF j� existe em outro registro
   var existenteCpf = await _repository.GetByCpfAsync(input.Cpf);
   if (existenteCpf != null && existenteCpf.IdResponsavel != input.IdResponsavel)
  {
            throw new InvalidOperationException("CPF j� cadastrado para outro respons�vel.");
        }

    var responsavel = new Domain.Models.ResponsavelFinanceiro
   {
    IdResponsavel = input.IdResponsavel,
    Nome = input.Nome,
     Cpf = input.Cpf,
  Rg = input.Rg,
  DataNascimento = input.DataNascimento,
    Telefone = input.Telefone,
   Celular = input.Celular,
  Email = input.Email,
  Cep = input.Cep,
     Logradouro = input.Logradouro,
  Numero = input.Numero,
   Complemento = input.Complemento,
  Bairro = input.Bairro,
      Cidade = input.Cidade,
 Estado = input.Estado,
  Ativo = input.Ativo
        };

if (!responsavel.ValidarDadosObrigatorios())
 {
    throw new InvalidOperationException("Dados obrigat�rios n�o preenchidos.");
  }

        await _repository.UpdateAsync(responsavel);
    }
}
