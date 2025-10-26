using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class CalcularMediaFinalUseCase
{
    private readonly INotaRepository _repository;

    public CalcularMediaFinalUseCase(INotaRepository repository) => _repository = repository;

    public async Task<decimal?> ExecuteAsync(int idMatricula, int idDisciplina)
    {
  var notas = await _repository.GetByMatriculaDisciplinaAsync(idMatricula, idDisciplina);
  var mediasPorBimestre = new List<decimal>();

   for (int bimestre = 1; bimestre <= 4; bimestre++)
        {
     var notasBimestre = notas.Where(n => n.Bimestre == bimestre).ToList();
 if (notasBimestre.Any())
       {
   var notasValores = notasBimestre.Select(n => n.NotaValor)
       .Where(n => n.HasValue).Select(n => n!.Value).ToList();
       var pesos = notasBimestre.Select(n => n.Peso).ToList();

      if (notasValores.Any())
    {
     var somaNotasPonderadas = notasValores.Zip(pesos, (nota, peso) => nota * peso).Sum();
      var somaPesos = pesos.Take(notasValores.Count).Sum();
          var mediaBimestre = somaPesos > 0 ? somaNotasPonderadas / somaPesos : 0;
       mediasPorBimestre.Add(mediaBimestre);
     }
     }
  }

        return mediasPorBimestre.Any() ? mediasPorBimestre.Average() : null;
  }
}
