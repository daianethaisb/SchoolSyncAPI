namespace SchoolSyncAPI.DTOs.Responses;

public class EstatisticaDisciplinaResponse
{
    public int IdDisciplina { get; set; }
    public string NomeDisciplina { get; set; } = string.Empty;
    public decimal MediaGeral { get; set; }
    public int TotalAvaliacoes { get; set; }
}
