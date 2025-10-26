namespace SchoolSyncAPI.DTOs.Responses;

public class BoletimResponse
{
    public int IdMatricula { get; set; }
    public string NumeroMatricula { get; set; } = string.Empty;
  public string NomeAluno { get; set; } = string.Empty;
    public string NomeTurma { get; set; } = string.Empty;
    public List<BoletimDisciplinaResponse> Disciplinas { get; set; } = new();
}

public class BoletimDisciplinaResponse
{
    public int IdDisciplina { get; set; }
    public string NomeDisciplina { get; set; } = string.Empty;
    public Dictionary<int, List<NotaItemResponse>> NotasPorBimestre { get; set; } = new();
    public Dictionary<int, decimal?>? MediasPorBimestre { get; set; }
    public decimal MediaFinal { get; set; }
}

public class NotaItemResponse
{
    public int IdNota { get; set; }
    public string? TipoAvaliacao { get; set; }
    public decimal? NotaValor { get; set; }
    public decimal Peso { get; set; }
    public DateTime? DataAvaliacao { get; set; }
}
