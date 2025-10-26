namespace SchoolSyncAPI.Application.UseCases.Estatistica.Outputs;

public class EstatisticaTurmaOutput
{
    public int IdTurma { get; set; }
    public string NomeTurma { get; set; } = string.Empty;
    public int TotalAlunos { get; set; }
    public int CapacidadeMaxima { get; set; }
    public decimal PercentualOcupacao { get; set; }
}
