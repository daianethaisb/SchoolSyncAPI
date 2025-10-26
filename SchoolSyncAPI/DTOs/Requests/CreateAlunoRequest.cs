using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class CreateAlunoRequest
{
   [Required(ErrorMessage = "Nome é obrigatório")]
  [MaxLength(200)]
   public string Nome { get; set; } = string.Empty;

    [MaxLength(14)]
    public string? Cpf { get; set; }

    [MaxLength(20)]
    public string? Rg { get; set; }

    [Required(ErrorMessage = "Data de nascimento é obrigatória")]
  public DateTime DataNascimento { get; set; }

   [Required(ErrorMessage = "Sexo é obrigatório")]
    [RegularExpression("[MFO]", ErrorMessage = "Sexo deve ser M, F ou O")]
    public char Sexo { get; set; }

    [MaxLength(20)]
 public string? Telefone { get; set; }

    [EmailAddress]
    [MaxLength(200)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Responsável financeiro é obrigatório")]
    public int IdResponsavelFinanceiro { get; set; }

  [MaxLength(10)]
    public string? Cep { get; set; }

  [MaxLength(200)]
    public string? Logradouro { get; set; }

    [MaxLength(20)]
    public string? Numero { get; set; }

 [MaxLength(100)]
    public string? Complemento { get; set; }

    [MaxLength(100)]
    public string? Bairro { get; set; }

  [MaxLength(100)]
    public string? Cidade { get; set; }

    [MaxLength(2)]
    public string? Estado { get; set; }

    public string? NecessidadesEspeciais { get; set; }

    public string? Observacoes { get; set; }
}
