namespace SchoolSyncAPI.Application.UseCases.Nota.Outputs;

public class MediaBimestreOutput
{
    public int IdMatricula { get; set; }
    public int IdDisciplina { get; set; }
    public int Bimestre { get; set; }
    public decimal? Media { get; set; }
    public int QuantidadeNotas { get; set; }
    public List<NotaDetalhadaOutput> Notas { get; set; } = new();
}
