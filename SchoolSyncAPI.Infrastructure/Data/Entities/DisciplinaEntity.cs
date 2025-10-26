using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSyncAPI.Infrastructure.Data.Entities;

[Table("disciplina")]
public class DisciplinaEntity
{
    [Key]
    [Column("id_disciplina")]
    public int IdDisciplina { get; set; }

    [Required]
 [MaxLength(100)]
  [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(20)]
    [Column("codigo")]
    public string? Codigo { get; set; }

    [Column("carga_horaria")]
    public int? CargaHoraria { get; set; }

    [Column("descricao")]
    public string? Descricao { get; set; }

    [Column("ativo")]
    public bool Ativo { get; set; } = true;

    // Navigation Properties
    public virtual ICollection<TurmaDisciplinaEntity> TurmaDisciplinas { get; set; } = new List<TurmaDisciplinaEntity>();
    public virtual ICollection<NotaEntity> Notas { get; set; } = new List<NotaEntity>();
}
