namespace SchoolSyncAPI.Domain.Models;

public class TurmaDisciplina
{
    public int IdTurmaDisciplina { get; set; }
    public int IdTurma { get; set; }
    public int IdDisciplina { get; set; }
    public string? ProfessorNome { get; set; }

    // Navigation Properties
    public Turma Turma { get; set; } = null!;
    public Disciplina Disciplina { get; set; } = null!;

    public TurmaDisciplina()
 {
    }

    public TurmaDisciplina(
        int idTurma,
        int idDisciplina,
     string? professorNome = null)
    {
        IdTurma = idTurma;
  IdDisciplina = idDisciplina;
        ProfessorNome = professorNome;
    }

    public bool ValidarDadosObrigatorios()
    {
  return IdTurma > 0 && IdDisciplina > 0;
    }
}
