using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.Matricula.Inputs;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Mappings;

public static class MatriculaMappingProfile
{
    public static CreateMatriculaInput ToInput(CreateMatriculaRequest request) => new()
    {
IdAluno = request.IdAluno, IdTurma = request.IdTurma, DataMatricula = request.DataMatricula,
   NumeroMatricula = request.NumeroMatricula, ValorMensalidade = request.ValorMensalidade,
        DiaVencimento = request.DiaVencimento, Observacoes = request.Observacoes
 };

    public static UpdateMatriculaInput ToUpdateInput(UpdateMatriculaRequest request, int id) => new()
    {
        IdMatricula = id, IdAluno = request.IdAluno, IdTurma = request.IdTurma, DataMatricula = request.DataMatricula,
        NumeroMatricula = request.NumeroMatricula, Situacao = request.Situacao, ValorMensalidade = request.ValorMensalidade,
        DiaVencimento = request.DiaVencimento, Observacoes = request.Observacoes
    };

    public static MatriculaResponse ToResponse(DomainModels.Matricula model) => new()
    {
        IdMatricula = model.IdMatricula, IdAluno = model.IdAluno, NomeAluno = model.Aluno?.Nome ?? "",
        IdTurma = model.IdTurma, NomeTurma = model.Turma?.Nome ?? "", DataMatricula = model.DataMatricula,
        NumeroMatricula = model.NumeroMatricula, Situacao = model.Situacao, ValorMensalidade = model.ValorMensalidade,
        DiaVencimento = model.DiaVencimento, Observacoes = model.Observacoes, DataCadastro = model.DataCadastro
    };
}
