namespace SchoolSyncAPI.Application.UseCases.Disciplina.Inputs;

public class UpdateDisciplinaInput
{
    public int IdDisciplina { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Codigo { get; set; }
  public int? CargaHoraria { get; set; }
    public string? Descricao { get; set; }
    public bool Ativo { get; set; }
}
