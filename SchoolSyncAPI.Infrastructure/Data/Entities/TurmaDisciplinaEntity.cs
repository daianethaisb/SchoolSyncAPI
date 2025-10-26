using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSyncAPI.Infrastructure.Data.Entities;

[Table("turma_disciplina")]
public class TurmaDisciplinaEntity
{
    [Key]
    [Column("id_turma_disciplina")]
    public int IdTurmaDisciplina { get; set; }

    [Required]
    [Column("id_turma")]
    public int IdTurma { get; set; }

    [Required]
    [Column("id_disciplina")]
    public int IdDisciplina { get; set; }

    [MaxLength(200)]
    [Column("professor_nome")]
    public string? ProfessorNome { get; set; }

    // Navigation Properties
    public virtual TurmaEntity Turma { get; set; } = null!;
    public virtual DisciplinaEntity Disciplina { get; set; } = null!;
}
