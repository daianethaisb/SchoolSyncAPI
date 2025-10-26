using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Application.UseCases.Nota.Outputs;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class GetBoletimAlunoUseCase
{
    private readonly INotaRepository _notaRepository;
    private readonly IMatriculaRepository _matriculaRepository;

    public GetBoletimAlunoUseCase(INotaRepository notaRepository, IMatriculaRepository matriculaRepository)
    {
        _notaRepository = notaRepository;
 _matriculaRepository = matriculaRepository;
    }

    public async Task<BoletimOutput> ExecuteAsync(int idMatricula)
    {
   var matricula = await _matriculaRepository.GetByIdAsync(idMatricula);
        if (matricula == null)
       throw new InvalidOperationException($"Matrícula com ID {idMatricula} não encontrada.");

        var notas = await _notaRepository.GetByMatriculaAsync(idMatricula);
   var notasPorDisciplina = notas.GroupBy(n => n.IdDisciplina);
   var disciplinas = new List<BoletimDisciplinaOutput>();

   foreach (var grupo in notasPorDisciplina)
   {
     var disciplinaId = grupo.Key;
    var notasDisciplina = grupo.ToList();
 var disciplinaOutput = new BoletimDisciplinaOutput
  {
       IdDisciplina = disciplinaId,
      NomeDisciplina = notasDisciplina.First().Disciplina?.Nome ?? "",
      NotasPorBimestre = new Dictionary<int, List<NotaDetalhadaOutput>>(),
     MediaFinal = 0
       };

   // Organizar por bimestre
   for (int bimestre = 1; bimestre <= 4; bimestre++)
   {
          var notasBimestre = notasDisciplina.Where(n => n.Bimestre == bimestre)
         .Select(n => new NotaDetalhadaOutput
  {
    IdNota = n.IdNota, TipoAvaliacao = n.TipoAvaliacao, NotaValor = n.NotaValor,
    Peso = n.Peso, DataAvaliacao = n.DataAvaliacao
        }).ToList();

            disciplinaOutput.NotasPorBimestre[bimestre] = notasBimestre;

    // Calcular média do bimestre
        if (notasBimestre.Any())
    {
        var mediaBimestre = CalcularMediaPonderada(
            notasBimestre.Select(n => n.NotaValor).ToList(),
 notasBimestre.Select(n => n.Peso).ToList());
     disciplinaOutput.MediasPorBimestre ??= new Dictionary<int, decimal?>();
        disciplinaOutput.MediasPorBimestre[bimestre] = mediaBimestre;
          }
            }

       // Calcular média final da disciplina
    if (disciplinaOutput.MediasPorBimestre != null && disciplinaOutput.MediasPorBimestre.Any())
   {
      var medias = disciplinaOutput.MediasPorBimestre.Values.Where(m => m.HasValue).Select(m => m!.Value).ToList();
    if (medias.Any()) disciplinaOutput.MediaFinal = medias.Average();
        }

      disciplinas.Add(disciplinaOutput);
        }

      return new BoletimOutput
        {
   IdMatricula = idMatricula, NumeroMatricula = matricula.NumeroMatricula,
  NomeAluno = matricula.Aluno?.Nome ?? "", NomeTurma = matricula.Turma?.Nome ?? "",
            Disciplinas = disciplinas
        };
    }

    private decimal? CalcularMediaPonderada(List<decimal?> notas, List<decimal> pesos)
    {
  var notasValidas = notas.Where(n => n.HasValue).Select(n => n!.Value).ToList();
        if (!notasValidas.Any()) return null;
   var somaNotasPonderadas = notasValidas.Zip(pesos, (nota, peso) => nota * peso).Sum();
   var somaPesos = pesos.Take(notasValidas.Count).Sum();
      return somaPesos > 0 ? somaNotasPonderadas / somaPesos : null;
    }
}
