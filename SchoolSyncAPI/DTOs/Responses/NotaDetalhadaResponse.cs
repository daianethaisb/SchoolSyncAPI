namespace SchoolSyncAPI.DTOs.Responses;

public class NotaDetalhadaResponse
{
    public int IdNota { get; set; }
    public int IdMatricula { get; set; }
  public string? NumeroMatricula { get; set; }
    public string? NomeAluno { get; set; }
    public int IdDisciplina { get; set; }
    public string? NomeDisciplina { get; set; }
    public string? TipoAvaliacao { get; set; }
    public int? Bimestre { get; set; }
    public decimal? NotaValor { get; set; }
    public decimal Peso { get; set; }
  public DateTime? DataAvaliacao { get; set; }
    public string? Observacoes { get; set; }
  public DateTime DataLancamento { get; set; }
}
