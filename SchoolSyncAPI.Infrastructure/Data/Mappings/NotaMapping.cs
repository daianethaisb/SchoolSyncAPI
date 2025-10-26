using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Mappings;

public static class NotaMapping
{
    public static NotaEntity ToEntity(Nota model)
    {
   return new NotaEntity
   {
    IdNota = model.IdNota,
    IdMatricula = model.IdMatricula,
      IdDisciplina = model.IdDisciplina,
   TipoAvaliacao = model.TipoAvaliacao,
     Bimestre = model.Bimestre,
          NotaValor = model.NotaValor,
    Peso = model.Peso,
       DataAvaliacao = model.DataAvaliacao,
     Observacoes = model.Observacoes,
  DataLancamento = model.DataLancamento
        };
    }

    public static Nota ToDomain(NotaEntity entity)
    {
        var nota = new Nota
 {
     IdNota = entity.IdNota,
   IdMatricula = entity.IdMatricula,
IdDisciplina = entity.IdDisciplina,
       TipoAvaliacao = entity.TipoAvaliacao,
  Bimestre = entity.Bimestre,
      NotaValor = entity.NotaValor,
 Peso = entity.Peso,
  DataAvaliacao = entity.DataAvaliacao,
 Observacoes = entity.Observacoes,
   DataLancamento = entity.DataLancamento
 };

     // Map navigation properties if loaded
        if (entity.Matricula != null)
    {
     nota.Matricula = MatriculaMapping.ToDomain(entity.Matricula);
}

      if (entity.Disciplina != null)
   {
         nota.Disciplina = DisciplinaMapping.ToDomain(entity.Disciplina);
        }

        return nota;
    }
}
