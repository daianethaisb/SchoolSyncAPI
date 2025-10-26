namespace SchoolSyncAPI.Application.UseCases.Nota.Inputs;

public class UpdateNotaInput
{
    public int IdNota { get; set; }
    public int? Bimestre { get; set; }
    public decimal? NotaValor { get; set; }
    public decimal Peso { get; set; }
    public DateTime? DataAvaliacao { get; set; }
    public string? Observacoes { get; set; }
}
