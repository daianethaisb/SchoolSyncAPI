using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Mappings;

public static class DisciplinaMapping
{
    public static DisciplinaEntity ToEntity(Disciplina model)
    {
        return new DisciplinaEntity
   {
 IdDisciplina = model.IdDisciplina,
       Nome = model.Nome,
   Codigo = model.Codigo,
     CargaHoraria = model.CargaHoraria,
     Descricao = model.Descricao,
          Ativo = model.Ativo
   };
    }

    public static Disciplina ToDomain(DisciplinaEntity entity)
    {
        return new Disciplina
        {
        IdDisciplina = entity.IdDisciplina,
 Nome = entity.Nome,
       Codigo = entity.Codigo,
    CargaHoraria = entity.CargaHoraria,
            Descricao = entity.Descricao,
  Ativo = entity.Ativo
   };
    }
}
