using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Application.UseCases.Nota.Outputs;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class CalcularMediaBimestreUseCase
{
    private readonly INotaRepository _repository;

    public CalcularMediaBimestreUseCase(INotaRepository repository) => _repository = repository;

    public async Task<MediaBimestreOutput> ExecuteAsync(int idMatricula, int idDisciplina, int bimestre)
    {
        var notas = await _repository.GetByMatriculaDisciplinaAsync(idMatricula, idDisciplina);
 var notasBimestre = notas.Where(n => n.Bimestre == bimestre).ToList();

   if (!notasBimestre.Any())
            return new MediaBimestreOutput { IdMatricula = idMatricula, IdDisciplina = idDisciplina, 
     Bimestre = bimestre, Media = null, QuantidadeNotas = 0 };

        var notasValores = notasBimestre.Select(n => n.NotaValor).Where(n => n.HasValue).Select(n => n!.Value).ToList();
  var pesos = notasBimestre.Select(n => n.Peso).ToList();
     decimal? media = null;

        if (notasValores.Any())
  {
     var somaNotasPonderadas = notasValores.Zip(pesos, (nota, peso) => nota * peso).Sum();
       var somaPesos = pesos.Take(notasValores.Count).Sum();
   media = somaPesos > 0 ? somaNotasPonderadas / somaPesos : null;
     }

return new MediaBimestreOutput
        {
  IdMatricula = idMatricula, IdDisciplina = idDisciplina, Bimestre = bimestre,
  Media = media, QuantidadeNotas = notasBimestre.Count,
       Notas = notasBimestre.Select(n => new NotaDetalhadaOutput
    {
      IdNota = n.IdNota, TipoAvaliacao = n.TipoAvaliacao, NotaValor = n.NotaValor,
    Peso = n.Peso, DataAvaliacao = n.DataAvaliacao
      }).ToList()
 };
    }
}
