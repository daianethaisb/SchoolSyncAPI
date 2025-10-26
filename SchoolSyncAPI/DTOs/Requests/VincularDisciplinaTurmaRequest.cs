using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class VincularDisciplinaTurmaRequest
{
    [Required(ErrorMessage = "ID da turma é obrigatório")]
    public int IdTurma { get; set; }

[Required(ErrorMessage = "ID da disciplina é obrigatório")]
    public int IdDisciplina { get; set; }

    [MaxLength(200)]
    public string? ProfessorNome { get; set; }
}
