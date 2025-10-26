namespace SchoolSyncAPI.DTOs.Responses;

public class TurmaResponse
{
    public int IdTurma { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int AnoLetivo { get; set; }
    public string Serie { get; set; } = string.Empty;
    public string Turno { get; set; } = string.Empty;
    public string? Sala { get; set; }
  public int CapacidadeMaxima { get; set; }
    public int VagasDisponiveis { get; set; }
  public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public bool Ativo { get; set; }
}
