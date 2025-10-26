using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Mappings;

public static class ResponsavelFinanceiroMapping
{
    public static ResponsavelFinanceiroEntity ToEntity(ResponsavelFinanceiro model)
 {
        return new ResponsavelFinanceiroEntity
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

    public static ResponsavelFinanceiro ToDomain(ResponsavelFinanceiroEntity entity)
    {
        return new ResponsavelFinanceiro
        {
    IdResponsavel = entity.IdResponsavel,
      Nome = entity.Nome,
            Cpf = entity.Cpf,
    Rg = entity.Rg,
     DataNascimento = entity.DataNascimento,
            Telefone = entity.Telefone,
            Celular = entity.Celular,
        Email = entity.Email,
            Cep = entity.Cep,
   Logradouro = entity.Logradouro,
 Numero = entity.Numero,
            Complemento = entity.Complemento,
 Bairro = entity.Bairro,
            Cidade = entity.Cidade,
            Estado = entity.Estado,
    DataCadastro = entity.DataCadastro,
 Ativo = entity.Ativo
    };
    }
}
