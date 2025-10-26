using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.Estatistica.Outputs;

namespace SchoolSyncAPI.Mappings;

public static class EstatisticaMappingProfile
{
    public static DashboardEstatisticasResponse ToResponse(DashboardEstatisticasOutput output) => new()
    {
        TotalAlunos = output.TotalAlunos,
        TotalAlunosAtivos = output.TotalAlunosAtivos,
 TotalResponsaveis = output.TotalResponsaveis,
        TotalTurmas = output.TotalTurmas,
        TotalTurmasAtivas = output.TotalTurmasAtivas,
        TotalDisciplinas = output.TotalDisciplinas,
        TotalMatriculas = output.TotalMatriculas,
        TotalMatriculasAtivas = output.TotalMatriculasAtivas,
        MediaGeralNotas = output.MediaGeralNotas,
        VagasDisponiveis = output.VagasDisponiveis,
        TaxaOcupacao = output.TaxaOcupacao,
     EstatisticasPorTurma = output.EstatisticasPorTurma.Select(ToTurmaResponse).ToList(),
  EstatisticasPorDisciplina = output.EstatisticasPorDisciplina.Select(ToDisciplinaResponse).ToList()
    };

    private static EstatisticaTurmaResponse ToTurmaResponse(EstatisticaTurmaOutput output) => new()
    {
        IdTurma = output.IdTurma,
        NomeTurma = output.NomeTurma,
        TotalAlunos = output.TotalAlunos,
        CapacidadeMaxima = output.CapacidadeMaxima,
    PercentualOcupacao = output.PercentualOcupacao
    };

    private static EstatisticaDisciplinaResponse ToDisciplinaResponse(EstatisticaDisciplinaOutput output) => new()
    {
      IdDisciplina = output.IdDisciplina,
   NomeDisciplina = output.NomeDisciplina,
        MediaGeral = output.MediaGeral,
        TotalAvaliacoes = output.TotalAvaliacoes
    };
}
