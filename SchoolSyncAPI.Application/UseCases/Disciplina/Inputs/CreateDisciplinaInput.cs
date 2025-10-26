namespace SchoolSyncAPI.Application.UseCases.Disciplina.Inputs;

public class CreateDisciplinaInput
{
  public string Nome { get; set; } = string.Empty;
    public string? Codigo { get; set; }
    public int? CargaHoraria { get; set; }
    public string? Descricao { get; set; }
}
