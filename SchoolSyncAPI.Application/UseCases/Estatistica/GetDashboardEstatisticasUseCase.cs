using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Application.UseCases.Estatistica.Outputs;

namespace SchoolSyncAPI.Application.UseCases.Estatistica;

public class GetDashboardEstatisticasUseCase
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IResponsavelFinanceiroRepository _responsavelRepository;
    private readonly ITurmaRepository _turmaRepository;
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly IDisciplinaRepository _disciplinaRepository;
    private readonly INotaRepository _notaRepository;

    public GetDashboardEstatisticasUseCase(
        IAlunoRepository alunoRepository,
     IResponsavelFinanceiroRepository responsavelRepository,
        ITurmaRepository turmaRepository,
     IMatriculaRepository matriculaRepository,
     IDisciplinaRepository disciplinaRepository,
        INotaRepository notaRepository)
{
        _alunoRepository = alunoRepository;
        _responsavelRepository = responsavelRepository;
   _turmaRepository = turmaRepository;
        _matriculaRepository = matriculaRepository;
  _disciplinaRepository = disciplinaRepository;
 _notaRepository = notaRepository;
    }

    public async Task<DashboardEstatisticasOutput> ExecuteAsync()
    {
    // Buscar todos os dados
        var alunos = await _alunoRepository.GetAllAsync();
        var responsaveis = await _responsavelRepository.GetAllAsync();
        var turmas = await _turmaRepository.GetAllAsync();
        var matriculas = await _matriculaRepository.GetAllAsync();
        var disciplinas = await _disciplinaRepository.GetAllAsync();
        var notas = await _notaRepository.GetAllAsync();

        // Calcular estatísticas gerais
   var totalAlunos = alunos.Count();
        var totalAlunosAtivos = alunos.Count(a => a.Ativo);
        var totalResponsaveis = responsaveis.Count();
        var totalTurmas = turmas.Count();
        var totalTurmasAtivas = turmas.Count(t => t.Ativo);
        var totalDisciplinas = disciplinas.Count();
        var totalMatriculas = matriculas.Count();
        var totalMatriculasAtivas = matriculas.Count(m => m.Situacao == "Ativa");

     // Calcular média geral das notas
        var notasComValor = notas.Where(n => n.NotaValor.HasValue).ToList();
        var mediaGeralNotas = notasComValor.Any() 
            ? Math.Round(notasComValor.Average(n => n.NotaValor!.Value), 2)
            : 0;

 // Calcular vagas disponíveis e taxa de ocupação
   var capacidadeTotal = turmas.Where(t => t.Ativo).Sum(t => t.CapacidadeMaxima);
        var alunosMatriculados = matriculas.Count(m => m.Situacao == "Ativa");
        var vagasDisponiveis = capacidadeTotal - alunosMatriculados;
        var taxaOcupacao = capacidadeTotal > 0 
            ? Math.Round((decimal)alunosMatriculados / capacidadeTotal * 100, 2)
        : 0;

    // Estatísticas por turma
        var estatisticasPorTurma = turmas
            .Select(t => new EstatisticaTurmaOutput
     {
          IdTurma = t.IdTurma,
                NomeTurma = $"{t.Serie} - Turma {t.Turno}",
      TotalAlunos = matriculas.Count(m => m.IdTurma == t.IdTurma && m.Situacao == "Ativa"),
        CapacidadeMaxima = t.CapacidadeMaxima,
   PercentualOcupacao = t.CapacidadeMaxima > 0 
      ? Math.Round((decimal)matriculas.Count(m => m.IdTurma == t.IdTurma && m.Situacao == "Ativa") / t.CapacidadeMaxima * 100, 2)
   : 0
   })
       .OrderByDescending(e => e.PercentualOcupacao)
            .ToList();

        // Estatísticas por disciplina
        var estatisticasPorDisciplina = disciplinas
          .Select(d =>
            {
        var notasDisciplina = notas.Where(n => n.IdDisciplina == d.IdDisciplina && n.NotaValor.HasValue).ToList();
    return new EstatisticaDisciplinaOutput
      {
  IdDisciplina = d.IdDisciplina,
      NomeDisciplina = d.Nome,
         MediaGeral = notasDisciplina.Any() 
   ? Math.Round(notasDisciplina.Average(n => n.NotaValor!.Value), 2)
        : 0,
            TotalAvaliacoes = notasDisciplina.Count
     };
         })
  .OrderByDescending(e => e.TotalAvaliacoes)
   .ToList();

 return new DashboardEstatisticasOutput
        {
        TotalAlunos = totalAlunos,
        TotalAlunosAtivos = totalAlunosAtivos,
      TotalResponsaveis = totalResponsaveis,
   TotalTurmas = totalTurmas,
        TotalTurmasAtivas = totalTurmasAtivas,
            TotalDisciplinas = totalDisciplinas,
            TotalMatriculas = totalMatriculas,
  TotalMatriculasAtivas = totalMatriculasAtivas,
    MediaGeralNotas = mediaGeralNotas,
            VagasDisponiveis = vagasDisponiveis,
            TaxaOcupacao = taxaOcupacao,
   EstatisticasPorTurma = estatisticasPorTurma,
 EstatisticasPorDisciplina = estatisticasPorDisciplina
        };
    }
}
