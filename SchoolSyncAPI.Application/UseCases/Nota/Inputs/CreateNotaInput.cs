namespace SchoolSyncAPI.Application.UseCases.Nota.Inputs;

public class CreateNotaInput
{
    public int IdMatricula { get; set; }
    public int IdDisciplina { get; set; }
    public string TipoAvaliacao { get; set; } = string.Empty;
    public int? Bimestre { get; set; }
    public decimal? NotaValor { get; set; }
    public decimal? Peso { get; set; }
    public DateTime? DataAvaliacao { get; set; }
    public string? Observacoes { get; set; }
}
