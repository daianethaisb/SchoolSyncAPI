namespace SchoolSyncAPI.Domain.Models;

public class Nota
{
    public int IdNota { get; set; }
    public int IdMatricula { get; set; }
    public int IdDisciplina { get; set; }
    public string TipoAvaliacao { get; set; } = string.Empty; // 'Prova', 'Trabalho', 'Seminário', 'Projeto', 'Participação', 'Outro'
    public int? Bimestre { get; set; }
    public decimal? NotaValor { get; set; }
    public decimal Peso { get; set; }
    public DateTime? DataAvaliacao { get; set; }
    public string? Observacoes { get; set; }
    public DateTime DataLancamento { get; set; }

    // Navigation Properties
    public Matricula Matricula { get; set; } = null!;
    public Disciplina Disciplina { get; set; } = null!;

    public Nota()
    {
        DataLancamento = DateTime.Now;
        Peso = 1.0m;
    }

    public Nota(
      int idMatricula,
  int idDisciplina,
        string tipoAvaliacao,
        int? bimestre = null,
        decimal? notaValor = null,
        decimal peso = 1.0m,
        DateTime? dataAvaliacao = null,
     string? observacoes = null) : this()
    {
     IdMatricula = idMatricula;
        IdDisciplina = idDisciplina;
        TipoAvaliacao = tipoAvaliacao;
        Bimestre = bimestre;
        NotaValor = notaValor;
        Peso = peso;
        DataAvaliacao = dataAvaliacao;
        Observacoes = observacoes;
 }

    public bool ValidarTipoAvaliacao()
    {
      var tiposValidos = new[] { "Prova", "Trabalho", "Seminário", "Projeto", "Participação", "Outro" };
        return tiposValidos.Contains(TipoAvaliacao);
    }

    public bool ValidarBimestre()
    {
        return !Bimestre.HasValue || (Bimestre >= 1 && Bimestre <= 4);
    }

  public bool ValidarNotaValor()
    {
        return !NotaValor.HasValue || (NotaValor >= 0 && NotaValor <= 10);
    }

    public decimal CalcularNotaPonderada()
    {
        return (NotaValor ?? 0) * Peso;
    }

    public bool ValidarDadosObrigatorios()
    {
        return IdMatricula > 0 &&
             IdDisciplina > 0 &&
    !string.IsNullOrWhiteSpace(TipoAvaliacao) &&
      ValidarTipoAvaliacao() &&
   ValidarBimestre() &&
         ValidarNotaValor() &&
       Peso > 0;
    }
}
