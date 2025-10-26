namespace SchoolSyncAPI.DTOs.Responses;

public class TurmaDisciplinaDetalhadaResponse
{
    public int IdTurmaDisciplina { get; set; }

    // Dados da Turma
  public int IdTurma { get; set; }
    public string NomeTurma { get; set; } = string.Empty;
    public string Serie { get; set; } = string.Empty;
    public int AnoLetivo { get; set; }

    // Dados da Disciplina
    public int IdDisciplina { get; set; }
    public string NomeDisciplina { get; set; } = string.Empty;
    public string? CodigoDisciplina { get; set; }
 public int? CargaHoraria { get; set; }

    // Professor
    public string? ProfessorNome { get; set; }
}
