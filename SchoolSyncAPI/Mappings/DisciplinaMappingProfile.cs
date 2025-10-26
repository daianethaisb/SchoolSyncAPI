using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.Disciplina.Inputs;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Mappings;

public static class DisciplinaMappingProfile
{
    public static CreateDisciplinaInput ToCreateInput(CreateDisciplinaRequest request) => new()
    {
  Nome = request.Nome,
  Codigo = request.Codigo,
        CargaHoraria = request.CargaHoraria,
        Descricao = request.Descricao
    };

  public static UpdateDisciplinaInput ToUpdateInput(UpdateDisciplinaRequest request, int id) => new()
    {
   IdDisciplina = id,
        Nome = request.Nome,
   Codigo = request.Codigo,
        CargaHoraria = request.CargaHoraria,
   Descricao = request.Descricao,
 Ativo = request.Ativo
    };

    public static DisciplinaResponse ToResponse(DomainModels.Disciplina disciplina) => new()
  {
  IdDisciplina = disciplina.IdDisciplina,
        Nome = disciplina.Nome,
        Codigo = disciplina.Codigo,
 CargaHoraria = disciplina.CargaHoraria,
  Descricao = disciplina.Descricao,
        Ativo = disciplina.Ativo
    };
}
