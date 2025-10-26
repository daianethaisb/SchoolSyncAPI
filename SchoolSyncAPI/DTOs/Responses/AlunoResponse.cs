namespace SchoolSyncAPI.DTOs.Responses;

public class AlunoResponse
{
    public int IdAluno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public string? Rg { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }
    public char Sexo { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public int IdResponsavelFinanceiro { get; set; }
    public string NomeResponsavel { get; set; } = string.Empty;
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
}
