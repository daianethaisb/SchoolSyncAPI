namespace SchoolSyncAPI.Domain.Models;

public class Aluno
{
    public int IdAluno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public string? Rg { get; set; }
    public DateTime DataNascimento { get; set; }
    public char Sexo { get; set; } // 'M', 'F' ou 'O'
    public string? Telefone { get; set; }
  public string? Email { get; set; }
    public int IdResponsavelFinanceiro { get; set; }
    public string? Cep { get; set; }
 public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? NecessidadesEspeciais { get; set; }
    public string? Observacoes { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    // Navigation Properties
    public ResponsavelFinanceiro ResponsavelFinanceiro { get; set; } = null!;
    public ICollection<Matricula> Matriculas { get; set; }

    public Aluno()
    {
        Matriculas = new List<Matricula>();
   DataCadastro = DateTime.Now;
        Ativo = true;
    }

    public Aluno(
        string nome,
     DateTime dataNascimento,
        char sexo,
        int idResponsavelFinanceiro,
string? cpf = null,
  string? rg = null,
 string? telefone = null,
   string? email = null,
    string? cep = null,
        string? logradouro = null,
        string? numero = null,
        string? complemento = null,
      string? bairro = null,
        string? cidade = null,
        string? estado = null,
     string? necessidadesEspeciais = null,
      string? observacoes = null) : this()
 {
    Nome = nome;
        DataNascimento = dataNascimento;
        Sexo = sexo;
        IdResponsavelFinanceiro = idResponsavelFinanceiro;
        Cpf = cpf;
  Rg = rg;
        Telefone = telefone;
     Email = email;
        Cep = cep;
        Logradouro = logradouro;
   Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
Cidade = cidade;
        Estado = estado;
      NecessidadesEspeciais = necessidadesEspeciais;
      Observacoes = observacoes;
    }

    public int CalcularIdade()
  {
   var hoje = DateTime.Today;
        var idade = hoje.Year - DataNascimento.Year;
   if (DataNascimento.Date > hoje.AddYears(-idade))
      idade--;
        return idade;
    }

    public bool ValidarSexo()
    {
   return Sexo == 'M' || Sexo == 'F' || Sexo == 'O';
    }

    public bool ValidarDadosObrigatorios()
    {
   return !string.IsNullOrWhiteSpace(Nome) &&
DataNascimento != default &&
     ValidarSexo() &&
               IdResponsavelFinanceiro > 0;
    }
}
