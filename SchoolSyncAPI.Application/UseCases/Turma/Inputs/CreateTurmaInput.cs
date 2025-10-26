namespace SchoolSyncAPI.Application.UseCases.Turma.Inputs;

public class CreateTurmaInput
{
    public string Nome { get; set; } = string.Empty;
    public int AnoLetivo { get; set; }
    public string Serie { get; set; } = string.Empty;
  public string Turno { get; set; } = string.Empty;
    public string? Sala { get; set; }
  public int CapacidadeMaxima { get; set; } = 30;
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
}
