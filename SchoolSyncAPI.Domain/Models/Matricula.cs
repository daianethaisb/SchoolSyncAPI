namespace SchoolSyncAPI.Domain.Models;

public class Matricula
{
    public int IdMatricula { get; set; }
    public int IdAluno { get; set; }
    public int IdTurma { get; set; }
    public DateTime DataMatricula { get; set; }
    public string NumeroMatricula { get; set; } = string.Empty;
    public string Situacao { get; set; } = string.Empty; // 'Ativa', 'Trancada', 'Cancelada', 'Concluída'
    public decimal? ValorMensalidade { get; set; }
    public int? DiaVencimento { get; set; }
    public string? Observacoes { get; set; }
    public DateTime DataCadastro { get; set; }

    // Navigation Properties
    public Aluno Aluno { get; set; } = null!;
    public Turma Turma { get; set; } = null!;
  public ICollection<Nota> Notas { get; set; }

    public Matricula()
    {
        Notas = new List<Nota>();
        DataMatricula = DateTime.Now;
        DataCadastro = DateTime.Now;
    Situacao = "Ativa";
    }

    public Matricula(
        int idAluno,
  int idTurma,
        string numeroMatricula,
        DateTime? dataMatricula = null,
        decimal? valorMensalidade = null,
      int? diaVencimento = null,
        string? observacoes = null) : this()
    {
        IdAluno = idAluno;
        IdTurma = idTurma;
        NumeroMatricula = numeroMatricula;
   if (dataMatricula.HasValue)
        DataMatricula = dataMatricula.Value;
        ValorMensalidade = valorMensalidade;
        DiaVencimento = diaVencimento;
      Observacoes = observacoes;
    }

    public bool ValidarSituacao()
    {
     var situacoesValidas = new[] { "Ativa", "Trancada", "Cancelada", "Concluída" };
  return situacoesValidas.Contains(Situacao);
    }

    public bool ValidarDiaVencimento()
    {
   return !DiaVencimento.HasValue || (DiaVencimento >= 1 && DiaVencimento <= 31);
    }

    public void Trancar()
    {
     if (Situacao == "Ativa")
            Situacao = "Trancada";
    }

    public void Cancelar()
    {
 if (Situacao == "Ativa" || Situacao == "Trancada")
  Situacao = "Cancelada";
    }

    public void Concluir()
    {
   if (Situacao == "Ativa")
            Situacao = "Concluída";
    }

    public void Reativar()
    {
        if (Situacao == "Trancada")
            Situacao = "Ativa";
 }

    public bool ValidarDadosObrigatorios()
    {
        return IdAluno > 0 &&
     IdTurma > 0 &&
      !string.IsNullOrWhiteSpace(NumeroMatricula) &&
 DataMatricula != default &&
           ValidarSituacao() &&
       ValidarDiaVencimento();
    }
}
