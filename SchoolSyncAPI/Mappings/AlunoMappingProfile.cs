using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.Aluno.Inputs;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Mappings;

public static class AlunoMappingProfile
{
    public static CreateAlunoInput ToInput(CreateAlunoRequest request) => new()
    {
        Nome = request.Nome, Cpf = request.Cpf, Rg = request.Rg, DataNascimento = request.DataNascimento,
        Sexo = request.Sexo, Telefone = request.Telefone, Email = request.Email, IdResponsavelFinanceiro = request.IdResponsavelFinanceiro,
        Cep = request.Cep, Logradouro = request.Logradouro, Numero = request.Numero, Complemento = request.Complemento,
        Bairro = request.Bairro, Cidade = request.Cidade, Estado = request.Estado, NecessidadesEspeciais = request.NecessidadesEspeciais,
        Observacoes = request.Observacoes
    };

    public static UpdateAlunoInput ToUpdateInput(UpdateAlunoRequest request, int id) => new()
    {
        IdAluno = id, Nome = request.Nome, Cpf = request.Cpf, Rg = request.Rg, DataNascimento = request.DataNascimento,
        Sexo = request.Sexo, Telefone = request.Telefone, Email = request.Email, IdResponsavelFinanceiro = request.IdResponsavelFinanceiro,
        Cep = request.Cep, Logradouro = request.Logradouro, Numero = request.Numero, Complemento = request.Complemento,
        Bairro = request.Bairro, Cidade = request.Cidade, Estado = request.Estado, NecessidadesEspeciais = request.NecessidadesEspeciais,
        Observacoes = request.Observacoes, Ativo = request.Ativo
    };

    public static AlunoResponse ToResponse(DomainModels.Aluno model) => new()
    {
        IdAluno = model.IdAluno, Nome = model.Nome, Cpf = model.Cpf, Rg = model.Rg, DataNascimento = model.DataNascimento,
        Idade = model.CalcularIdade(), Sexo = model.Sexo, Telefone = model.Telefone, Email = model.Email,
        IdResponsavelFinanceiro = model.IdResponsavelFinanceiro, NomeResponsavel = model.ResponsavelFinanceiro?.Nome ?? "",
        Cep = model.Cep, Logradouro = model.Logradouro, Numero = model.Numero, Complemento = model.Complemento,
        Bairro = model.Bairro, Cidade = model.Cidade, Estado = model.Estado, NecessidadesEspeciais = model.NecessidadesEspeciais,
        Observacoes = model.Observacoes, DataCadastro = model.DataCadastro, Ativo = model.Ativo
    };
}
