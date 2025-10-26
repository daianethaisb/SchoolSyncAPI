namespace SchoolSyncAPI.DTOs.Responses;

public class MediaBimestreResponse
{
  public int IdMatricula { get; set; }
    public int IdDisciplina { get; set; }
 public int Bimestre { get; set; }
    public decimal? Media { get; set; }
  public int QuantidadeNotas { get; set; }
    public List<NotaItemResponse> Notas { get; set; } = new();
}
