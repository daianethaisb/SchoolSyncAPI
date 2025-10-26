namespace SchoolSyncAPI.Application.UseCases.Matricula.Inputs;

public class UpdateMatriculaInput
{
  public int IdMatricula { get; set; }
  public int IdAluno { get; set; }
    public int IdTurma { get; set; }
  public DateTime DataMatricula { get; set; }
    public string NumeroMatricula { get; set; } = string.Empty;
    public string Situacao { get; set; } = string.Empty;
    public decimal? ValorMensalidade { get; set; }
    public int? DiaVencimento { get; set; }
    public string? Observacoes { get; set; }
}
