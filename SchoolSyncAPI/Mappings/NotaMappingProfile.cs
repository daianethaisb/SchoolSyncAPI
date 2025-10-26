using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.Nota.Inputs;
using SchoolSyncAPI.Application.UseCases.Nota.Outputs;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Mappings;

public static class NotaMappingProfile
{
    public static CreateNotaInput ToCreateInput(CreateNotaRequest request) => new()
    {
        IdMatricula = request.IdMatricula, IdDisciplina = request.IdDisciplina, TipoAvaliacao = request.TipoAvaliacao,
        Bimestre = request.Bimestre, NotaValor = request.NotaValor, Peso = request.Peso,
        DataAvaliacao = request.DataAvaliacao, Observacoes = request.Observacoes
    };

    public static UpdateNotaInput ToUpdateInput(UpdateNotaRequest request, int id) => new()
    {
        IdNota = id, 
      Bimestre = request.Bimestre,
        NotaValor = request.NotaValor, 
        Peso = request.Peso,
    DataAvaliacao = request.DataAvaliacao, 
        Observacoes = request.Observacoes
    };

public static NotaResponse ToResponse(DomainModels.Nota nota) => new()
    {
        IdNota = nota.IdNota, 
        IdMatricula = nota.IdMatricula, 
    IdDisciplina = nota.IdDisciplina,
        TipoAvaliacao = nota.TipoAvaliacao, 
    Bimestre = nota.Bimestre, 
        NotaValor = nota.NotaValor,
        Peso = nota.Peso, 
     DataAvaliacao = nota.DataAvaliacao, 
        Observacoes = nota.Observacoes,
     DataLancamento = nota.DataLancamento
    };

    public static NotaDetalhadaResponse ToDetalhadaResponse(DomainModels.Nota nota) => new()
  {
        IdNota = nota.IdNota, IdMatricula = nota.IdMatricula, NumeroMatricula = nota.Matricula?.NumeroMatricula,
        NomeAluno = nota.Matricula?.Aluno?.Nome, IdDisciplina = nota.IdDisciplina, NomeDisciplina = nota.Disciplina?.Nome,
        TipoAvaliacao = nota.TipoAvaliacao, Bimestre = nota.Bimestre, NotaValor = nota.NotaValor,
    Peso = nota.Peso, DataAvaliacao = nota.DataAvaliacao, Observacoes = nota.Observacoes,
        DataLancamento = nota.DataLancamento
    };

    public static BoletimResponse ToBoletimResponse(BoletimOutput output) => new()
    {
   IdMatricula = output.IdMatricula, NumeroMatricula = output.NumeroMatricula,
        NomeAluno = output.NomeAluno, NomeTurma = output.NomeTurma,
        Disciplinas = output.Disciplinas.Select(d => new BoletimDisciplinaResponse
        {
            IdDisciplina = d.IdDisciplina, NomeDisciplina = d.NomeDisciplina,
            NotasPorBimestre = d.NotasPorBimestre.ToDictionary(kvp => kvp.Key,
  kvp => kvp.Value.Select(n => new NotaItemResponse
                {
    IdNota = n.IdNota, TipoAvaliacao = n.TipoAvaliacao, NotaValor = n.NotaValor,
Peso = n.Peso, DataAvaliacao = n.DataAvaliacao
         }).ToList()),
   MediasPorBimestre = d.MediasPorBimestre, MediaFinal = d.MediaFinal
        }).ToList()
    };

    public static MediaBimestreResponse ToMediaBimestreResponse(MediaBimestreOutput output) => new()
    {
        IdMatricula = output.IdMatricula, IdDisciplina = output.IdDisciplina, Bimestre = output.Bimestre,
        Media = output.Media, QuantidadeNotas = output.QuantidadeNotas,
        Notas = output.Notas.Select(n => new NotaItemResponse
  {
            IdNota = n.IdNota, TipoAvaliacao = n.TipoAvaliacao, NotaValor = n.NotaValor,
   Peso = n.Peso, DataAvaliacao = n.DataAvaliacao
        }).ToList()
    };
}
