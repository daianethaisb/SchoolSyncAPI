namespace SchoolSyncAPI.Domain.Models;

public class Disciplina
{
    public int IdDisciplina { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Codigo { get; set; }
    public int? CargaHoraria { get; set; }
    public string? Descricao { get; set; }
    public bool Ativo { get; set; }

    // Navigation Properties
    public ICollection<TurmaDisciplina> TurmaDisciplinas { get; set; }
    public ICollection<Nota> Notas { get; set; }

public Disciplina()
    {
        TurmaDisciplinas = new List<TurmaDisciplina>();
        Notas = new List<Nota>();
        Ativo = true;
    }

    public Disciplina(
 string nome,
    string? codigo = null,
   int? cargaHoraria = null,
      string? descricao = null) : this()
    {
        Nome = nome;
        Codigo = codigo;
        CargaHoraria = cargaHoraria;
      Descricao = descricao;
    }

    public bool ValidarCargaHoraria()
    {
        return !CargaHoraria.HasValue || CargaHoraria > 0;
    }

    public bool ValidarDadosObrigatorios()
    {
        return !string.IsNullOrWhiteSpace(Nome) &&
 ValidarCargaHoraria();
    }
}
