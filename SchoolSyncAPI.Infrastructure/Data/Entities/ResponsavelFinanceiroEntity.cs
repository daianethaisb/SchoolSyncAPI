using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSyncAPI.Infrastructure.Data.Entities;

[Table("responsavel_financeiro")]
public class ResponsavelFinanceiroEntity
{
    [Key]
    [Column("id_responsavel")]
    public int IdResponsavel { get; set; }

    [Required]
    [MaxLength(200)]
    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(14)]
    [Column("cpf")]
    public string Cpf { get; set; } = string.Empty;

    [MaxLength(20)]
    [Column("rg")]
    public string? Rg { get; set; }

    [Column("data_nascimento")]
    public DateTime? DataNascimento { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("telefone")]
    public string Telefone { get; set; } = string.Empty;

    [MaxLength(20)]
    [Column("celular")]
    public string? Celular { get; set; }

    [MaxLength(200)]
    [Column("email")]
    public string? Email { get; set; }

    [MaxLength(10)]
    [Column("cep")]
    public string? Cep { get; set; }

    [MaxLength(200)]
    [Column("logradouro")]
    public string? Logradouro { get; set; }

    [MaxLength(20)]
  [Column("numero")]
    public string? Numero { get; set; }

    [MaxLength(100)]
    [Column("complemento")]
  public string? Complemento { get; set; }

    [MaxLength(100)]
    [Column("bairro")]
    public string? Bairro { get; set; }

    [MaxLength(100)]
 [Column("cidade")]
    public string? Cidade { get; set; }

    [MaxLength(2)]
    [Column("estado")]
    public string? Estado { get; set; }

    [Column("data_cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Column("ativo")]
    public bool Ativo { get; set; } = true;

    // Navigation Properties
    public virtual ICollection<AlunoEntity> Alunos { get; set; } = new List<AlunoEntity>();
}
