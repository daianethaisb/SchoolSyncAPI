using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSyncAPI.Infrastructure.Data.Entities;

[Table("nota")]
public class NotaEntity
{
    [Key]
    [Column("id_nota")]
    public int IdNota { get; set; }

    [Required]
    [Column("id_matricula")]
    public int IdMatricula { get; set; }

    [Required]
    [Column("id_disciplina")]
    public int IdDisciplina { get; set; }

    [Required]
    [MaxLength(20)]
[Column("tipo_avaliacao")]
    public string TipoAvaliacao { get; set; } = string.Empty;

    [Column("bimestre")]
  public int? Bimestre { get; set; }

    [Column("nota_valor", TypeName = "decimal(5,2)")]
    public decimal? NotaValor { get; set; }

    [Column("peso", TypeName = "decimal(5,2)")]
 public decimal Peso { get; set; } = 1.0m;

    [Column("data_avaliacao")]
    public DateTime? DataAvaliacao { get; set; }

    [Column("observacoes")]
    public string? Observacoes { get; set; }

    [Column("data_lancamento")]
    public DateTime DataLancamento { get; set; } = DateTime.Now;

    // Navigation Properties
    public virtual MatriculaEntity Matricula { get; set; } = null!;
  public virtual DisciplinaEntity Disciplina { get; set; } = null!;
}
