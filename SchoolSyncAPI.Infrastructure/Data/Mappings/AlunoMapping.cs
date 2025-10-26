using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Mappings;

public static class AlunoMapping
{
    public static AlunoEntity ToEntity(Aluno model)
  {
      return new AlunoEntity
        {
     IdAluno = model.IdAluno,
      Nome = model.Nome,
   Cpf = model.Cpf,
            Rg = model.Rg,
     DataNascimento = model.DataNascimento,
         Sexo = model.Sexo,
       Telefone = model.Telefone,
    Email = model.Email,
     IdResponsavelFinanceiro = model.IdResponsavelFinanceiro,
  Cep = model.Cep,
            Logradouro = model.Logradouro,
  Numero = model.Numero,
    Complemento = model.Complemento,
     Bairro = model.Bairro,
     Cidade = model.Cidade,
  Estado = model.Estado,
          NecessidadesEspeciais = model.NecessidadesEspeciais,
    Observacoes = model.Observacoes,
  DataCadastro = model.DataCadastro,
    Ativo = model.Ativo
  };
    }

    public static Aluno ToDomain(AlunoEntity entity)
{
        return new Aluno
     {
       IdAluno = entity.IdAluno,
            Nome = entity.Nome,
       Cpf = entity.Cpf,
     Rg = entity.Rg,
   DataNascimento = entity.DataNascimento,
            Sexo = entity.Sexo,
  Telefone = entity.Telefone,
            Email = entity.Email,
     IdResponsavelFinanceiro = entity.IdResponsavelFinanceiro,
      Cep = entity.Cep,
     Logradouro = entity.Logradouro,
     Numero = entity.Numero,
   Complemento = entity.Complemento,
            Bairro = entity.Bairro,
            Cidade = entity.Cidade,
            Estado = entity.Estado,
            NecessidadesEspeciais = entity.NecessidadesEspeciais,
   Observacoes = entity.Observacoes,
 DataCadastro = entity.DataCadastro,
            Ativo = entity.Ativo,
         ResponsavelFinanceiro = entity.ResponsavelFinanceiro != null 
       ? ResponsavelFinanceiroMapping.ToDomain(entity.ResponsavelFinanceiro)
       : null!
        };
    }
}
