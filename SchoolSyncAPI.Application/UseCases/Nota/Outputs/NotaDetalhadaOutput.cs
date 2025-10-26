namespace SchoolSyncAPI.Application.UseCases.Nota.Outputs;

public class NotaDetalhadaOutput
{
    public int IdNota { get; set; }
    public string? TipoAvaliacao { get; set; }
    public decimal? NotaValor { get; set; }
    public decimal Peso { get; set; }
    public DateTime? DataAvaliacao { get; set; }
}
