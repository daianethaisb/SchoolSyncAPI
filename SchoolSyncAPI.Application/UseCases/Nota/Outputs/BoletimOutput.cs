namespace SchoolSyncAPI.Application.UseCases.Nota.Outputs;

public class BoletimOutput
{
    public int IdMatricula { get; set; }
    public string NumeroMatricula { get; set; } = string.Empty;
    public string NomeAluno { get; set; } = string.Empty;
    public string NomeTurma { get; set; } = string.Empty;
    public List<BoletimDisciplinaOutput> Disciplinas { get; set; } = new();
}

public class BoletimDisciplinaOutput
{
    public int IdDisciplina { get; set; }
    public string NomeDisciplina { get; set; } = string.Empty;
    public Dictionary<int, List<NotaDetalhadaOutput>> NotasPorBimestre { get; set; } = new();
  public Dictionary<int, decimal?>? MediasPorBimestre { get; set; }
    public decimal MediaFinal { get; set; }
}
