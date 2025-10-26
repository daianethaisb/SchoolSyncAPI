using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSyncAPI.Infrastructure.Data.Entities;

[Table("matricula")]
public class MatriculaEntity
{
    [Key]
    [Column("id_matricula")]
    public int IdMatricula { get; set; }

    [Required]
    [Column("id_aluno")]
    public int IdAluno { get; set; }

    [Required]
    [Column("id_turma")]
    public int IdTurma { get; set; }

    [Required]
    [Column("data_matricula")]
    public DateTime DataMatricula { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("numero_matricula")]
    public string NumeroMatricula { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [Column("situacao")]
    public string Situacao { get; set; } = "Ativa";

    [Column("valor_mensalidade", TypeName = "decimal(10,2)")]
    public decimal? ValorMensalidade { get; set; }

    [Column("dia_vencimento")]
    public int? DiaVencimento { get; set; }

    [Column("observacoes")]
    public string? Observacoes { get; set; }

    [Column("data_cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    // Navigation Properties
    public virtual AlunoEntity Aluno { get; set; } = null!;
    public virtual TurmaEntity Turma { get; set; } = null!;
    public virtual ICollection<NotaEntity> Notas { get; set; } = new List<NotaEntity>();
}
