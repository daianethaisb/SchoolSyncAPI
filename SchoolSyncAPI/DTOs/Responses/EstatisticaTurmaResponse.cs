namespace SchoolSyncAPI.DTOs.Responses;

public class EstatisticaTurmaResponse
{
    public int IdTurma { get; set; }
    public string NomeTurma { get; set; } = string.Empty;
    public int TotalAlunos { get; set; }
    public int CapacidadeMaxima { get; set; }
    public decimal PercentualOcupacao { get; set; }
}
