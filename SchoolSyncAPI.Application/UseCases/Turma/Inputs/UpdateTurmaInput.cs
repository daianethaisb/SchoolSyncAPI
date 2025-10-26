namespace SchoolSyncAPI.Application.UseCases.Turma.Inputs;

public class UpdateTurmaInput
{
    public int IdTurma { get; set; }
  public string Nome { get; set; } = string.Empty;
  public int AnoLetivo { get; set; }
    public string Serie { get; set; } = string.Empty;
  public string Turno { get; set; } = string.Empty;
    public string? Sala { get; set; }
  public int CapacidadeMaxima { get; set; }
    public DateTime? DataInicio { get; set; }
 public DateTime? DataFim { get; set; }
    public bool Ativo { get; set; }
}
