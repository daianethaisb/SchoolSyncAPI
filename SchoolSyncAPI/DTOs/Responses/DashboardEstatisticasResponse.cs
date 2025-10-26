namespace SchoolSyncAPI.DTOs.Responses;

public class DashboardEstatisticasResponse
{
    public int TotalAlunos { get; set; }
    public int TotalAlunosAtivos { get; set; }
    public int TotalResponsaveis { get; set; }
    public int TotalTurmas { get; set; }
    public int TotalTurmasAtivas { get; set; }
    public int TotalDisciplinas { get; set; }
    public int TotalMatriculas { get; set; }
    public int TotalMatriculasAtivas { get; set; }
    public decimal MediaGeralNotas { get; set; }
    public int VagasDisponiveis { get; set; }
 public decimal TaxaOcupacao { get; set; }
    public List<EstatisticaTurmaResponse> EstatisticasPorTurma { get; set; } = new();
    public List<EstatisticaDisciplinaResponse> EstatisticasPorDisciplina { get; set; } = new();
}
