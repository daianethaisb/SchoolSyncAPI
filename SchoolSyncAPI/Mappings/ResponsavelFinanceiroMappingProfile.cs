using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro.Inputs;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Mappings;

public static class ResponsavelFinanceiroMappingProfile
{
    public static CreateResponsavelInput ToInput(CreateResponsavelRequest request)
    {
   return new CreateResponsavelInput
        {
 Nome = request.Nome,
   Cpf = request.Cpf,
       Rg = request.Rg,
  DataNascimento = request.DataNascimento,
            Telefone = request.Telefone,
    Celular = request.Celular,
            Email = request.Email,
      Cep = request.Cep,
          Logradouro = request.Logradouro,
   Numero = request.Numero,
          Complemento = request.Complemento,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
   Estado = request.Estado
 };
    }

    public static UpdateResponsavelInput ToUpdateInput(UpdateResponsavelRequest request, int id)
    {
    return new UpdateResponsavelInput
        {
            IdResponsavel = id,
        Nome = request.Nome,
 Cpf = request.Cpf,
          Rg = request.Rg,
        DataNascimento = request.DataNascimento,
    Telefone = request.Telefone,
       Celular = request.Celular,
            Email = request.Email,
 Cep = request.Cep,
  Logradouro = request.Logradouro,
     Numero = request.Numero,
Complemento = request.Complemento,
    Bairro = request.Bairro,
           Cidade = request.Cidade,
            Estado = request.Estado,
       Ativo = request.Ativo
        };
    }

 public static ResponsavelFinanceiroResponse ToResponse(DomainModels.ResponsavelFinanceiro model)
    {
  return new ResponsavelFinanceiroResponse
      {
            IdResponsavel = model.IdResponsavel,
            Nome = model.Nome,
    Cpf = model.Cpf,
            Rg = model.Rg,
   DataNascimento = model.DataNascimento,
            Telefone = model.Telefone,
     Celular = model.Celular,
          Email = model.Email,
            Cep = model.Cep,
Logradouro = model.Logradouro,
    Numero = model.Numero,
      Complemento = model.Complemento,
   Bairro = model.Bairro,
  Cidade = model.Cidade,
   Estado = model.Estado,
            DataCadastro = model.DataCadastro,
   Ativo = model.Ativo
        };
    }
}
