namespace SchoolSyncAPI.DTOs.Responses;

public class MatriculaResponse
{
    public int IdMatricula { get; set; }
public int IdAluno { get; set; }
    public string NomeAluno { get; set; } = string.Empty;
    public int IdTurma { get; set; }
    public string NomeTurma { get; set; } = string.Empty;
    public DateTime DataMatricula { get; set; }
    public string NumeroMatricula { get; set; } = string.Empty;
    public string Situacao { get; set; } = string.Empty;
    public decimal? ValorMensalidade { get; set; }
    public int? DiaVencimento { get; set; }
    public string? Observacoes { get; set; }
    public DateTime DataCadastro { get; set; }
}
