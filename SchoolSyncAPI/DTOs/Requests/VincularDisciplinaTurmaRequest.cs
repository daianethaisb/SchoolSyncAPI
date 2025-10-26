using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class VincularDisciplinaTurmaRequest
{
    [Required(ErrorMessage = "ID da turma � obrigat�rio")]
    public int IdTurma { get; set; }

[Required(ErrorMessage = "ID da disciplina � obrigat�rio")]
    public int IdDisciplina { get; set; }

    [MaxLength(200)]
    public string? ProfessorNome { get; set; }
}
