namespace SchoolSyncAPI.Domain.Models;

public class Turma
{
    public int IdTurma { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int AnoLetivo { get; set; }
    public string Serie { get; set; } = string.Empty;
    public string Turno { get; set; } = string.Empty; // 'Manhã', 'Tarde', 'Noite', 'Integral'
    public string? Sala { get; set; }
    public int CapacidadeMaxima { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public bool Ativo { get; set; }

    // Navigation Properties
    public ICollection<Matricula> Matriculas { get; set; }
    public ICollection<TurmaDisciplina> TurmaDisciplinas { get; set; }

    public Turma()
    {
        Matriculas = new List<Matricula>();
        TurmaDisciplinas = new List<TurmaDisciplina>();
        CapacidadeMaxima = 30;
    Ativo = true;
    }

    public Turma(
        string nome,
        int anoLetivo,
        string serie,
        string turno,
  int capacidadeMaxima = 30,
        string? sala = null,
        DateTime? dataInicio = null,
        DateTime? dataFim = null) : this()
    {
  Nome = nome;
   AnoLetivo = anoLetivo;
 Serie = serie;
        Turno = turno;
      CapacidadeMaxima = capacidadeMaxima;
      Sala = sala;
        DataInicio = dataInicio;
   DataFim = dataFim;
    }

    public bool ValidarTurno()
    {
    var turnosValidos = new[] { "Manhã", "Tarde", "Noite", "Integral" };
        return turnosValidos.Contains(Turno);
    }

 public int ObterVagasDisponiveis()
    {
  var matriculasAtivas = Matriculas?.Count(m => m.Situacao == "Ativa") ?? 0;
        return CapacidadeMaxima - matriculasAtivas;
    }

    public bool PossuiVagasDisponiveis()
    {
    return ObterVagasDisponiveis() > 0;
 }

 public bool ValidarDadosObrigatorios()
    {
        return !string.IsNullOrWhiteSpace(Nome) &&
         AnoLetivo > 0 &&
          !string.IsNullOrWhiteSpace(Serie) &&
      !string.IsNullOrWhiteSpace(Turno) &&
     CapacidadeMaxima > 0;
    }
}
