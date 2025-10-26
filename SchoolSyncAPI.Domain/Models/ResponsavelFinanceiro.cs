namespace SchoolSyncAPI.Domain.Models;

public class ResponsavelFinanceiro
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
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    // Navigation Properties
    public ICollection<Aluno> Alunos { get; set; }

public ResponsavelFinanceiro()
    {
      Alunos = new List<Aluno>();
        DataCadastro = DateTime.Now;
        Ativo = true;
    }

    public ResponsavelFinanceiro(
        string nome, 
  string cpf, 
        string telefone,
 string? rg = null,
        DateTime? dataNascimento = null,
        string? celular = null,
        string? email = null,
        string? cep = null,
        string? logradouro = null,
      string? numero = null,
 string? complemento = null,
        string? bairro = null,
     string? cidade = null,
        string? estado = null) : this()
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
        Rg = rg;
        DataNascimento = dataNascimento;
        Celular = celular;
        Email = email;
    Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
    }

    public bool ValidarCpf()
    {
        if (string.IsNullOrWhiteSpace(Cpf))
       return false;

        var cpfLimpo = new string(Cpf.Where(char.IsDigit).ToArray());
        return cpfLimpo.Length == 11;
  }

    public bool ValidarDadosObrigatorios()
    {
        return !string.IsNullOrWhiteSpace(Nome) &&
!string.IsNullOrWhiteSpace(Cpf) &&
        !string.IsNullOrWhiteSpace(Telefone);
    }
}
