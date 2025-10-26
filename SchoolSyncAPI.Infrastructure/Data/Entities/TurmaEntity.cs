using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSyncAPI.Infrastructure.Data.Entities;

[Table("turma")]
public class TurmaEntity
{
    [Key]
 [Column("id_turma")]
    public int IdTurma { get; set; }

    [Required]
    [MaxLength(100)]
  [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
  [Column("ano_letivo")]
    public int AnoLetivo { get; set; }

    [Required]
 [MaxLength(50)]
    [Column("serie")]
    public string Serie { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [Column("turno")]
    public string Turno { get; set; } = string.Empty;

  [MaxLength(50)]
[Column("sala")]
    public string? Sala { get; set; }

    [Column("capacidade_maxima")]
    public int CapacidadeMaxima { get; set; } = 30;

    [Column("data_inicio")]
    public DateTime? DataInicio { get; set; }

    [Column("data_fim")]
    public DateTime? DataFim { get; set; }

  [Column("ativo")]
    public bool Ativo { get; set; } = true;

    // Navigation Properties
    public virtual ICollection<MatriculaEntity> Matriculas { get; set; } = new List<MatriculaEntity>();
  public virtual ICollection<TurmaDisciplinaEntity> TurmaDisciplinas { get; set; } = new List<TurmaDisciplinaEntity>();
}
