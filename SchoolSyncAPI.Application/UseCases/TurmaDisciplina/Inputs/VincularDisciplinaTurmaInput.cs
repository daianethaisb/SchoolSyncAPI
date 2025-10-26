namespace SchoolSyncAPI.Application.UseCases.TurmaDisciplina.Inputs;

public class VincularDisciplinaTurmaInput
{
  public int IdTurma { get; set; }
    public int IdDisciplina { get; set; }
    public string? ProfessorNome { get; set; }
}
