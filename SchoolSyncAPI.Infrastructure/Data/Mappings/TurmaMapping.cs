using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Mappings;

public static class TurmaMapping
{
    public static TurmaEntity ToEntity(Turma model)
  {
   return new TurmaEntity
        {
    IdTurma = model.IdTurma,
     Nome = model.Nome,
     AnoLetivo = model.AnoLetivo,
       Serie = model.Serie,
   Turno = model.Turno,
            Sala = model.Sala,
        CapacidadeMaxima = model.CapacidadeMaxima,
     DataInicio = model.DataInicio,
     DataFim = model.DataFim,
            Ativo = model.Ativo
  };
    }

    public static Turma ToDomain(TurmaEntity entity)
    {
        return new Turma
{
       IdTurma = entity.IdTurma,
    Nome = entity.Nome,
   AnoLetivo = entity.AnoLetivo,
     Serie = entity.Serie,
  Turno = entity.Turno,
     Sala = entity.Sala,
      CapacidadeMaxima = entity.CapacidadeMaxima,
   DataInicio = entity.DataInicio,
        DataFim = entity.DataFim,
      Ativo = entity.Ativo
        };
    }
}
