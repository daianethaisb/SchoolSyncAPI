using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.TurmaDisciplina.Inputs;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Mappings;

public static class TurmaDisciplinaMappingProfile
{
    public static VincularDisciplinaTurmaInput ToVincularInput(VincularDisciplinaTurmaRequest request) => new()
    {
  IdTurma = request.IdTurma,
  IdDisciplina = request.IdDisciplina,
        ProfessorNome = request.ProfessorNome
    };

  public static TurmaDisciplinaResponse ToResponse(DomainModels.TurmaDisciplina turmaDisciplina) => new()
    {
      IdTurmaDisciplina = turmaDisciplina.IdTurmaDisciplina,
        IdTurma = turmaDisciplina.IdTurma,
   IdDisciplina = turmaDisciplina.IdDisciplina,
        ProfessorNome = turmaDisciplina.ProfessorNome
    };

    public static TurmaDisciplinaDetalhadaResponse ToDetalhadaResponse(DomainModels.TurmaDisciplina turmaDisciplina) => new()
    {
        IdTurmaDisciplina = turmaDisciplina.IdTurmaDisciplina,

 // Dados da Turma (assumindo navigation property carregada)
        IdTurma = turmaDisciplina.IdTurma,
        NomeTurma = turmaDisciplina.Turma?.Nome ?? "",
  Serie = turmaDisciplina.Turma?.Serie ?? "",
        AnoLetivo = turmaDisciplina.Turma?.AnoLetivo ?? 0,

   // Dados da Disciplina
 IdDisciplina = turmaDisciplina.IdDisciplina,
        NomeDisciplina = turmaDisciplina.Disciplina?.Nome ?? "",
        CodigoDisciplina = turmaDisciplina.Disciplina?.Codigo,
        CargaHoraria = turmaDisciplina.Disciplina?.CargaHoraria,

        // Professor
   ProfessorNome = turmaDisciplina.ProfessorNome
    };
}
