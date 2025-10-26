namespace SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro.Inputs;

public class UpdateResponsavelInput
{
  public int IdResponsavel { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
  public string? Rg { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string? Celular { get; set; }
  public string? Email { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
  public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public bool Ativo { get; set; }
}
