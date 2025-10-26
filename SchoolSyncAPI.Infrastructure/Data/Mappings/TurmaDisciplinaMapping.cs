using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Mappings;

public static class TurmaDisciplinaMapping
{
    public static TurmaDisciplinaEntity ToEntity(TurmaDisciplina model)
    {
    return new TurmaDisciplinaEntity
 {
      IdTurmaDisciplina = model.IdTurmaDisciplina,
   IdTurma = model.IdTurma,
        IdDisciplina = model.IdDisciplina,
 ProfessorNome = model.ProfessorNome
        };
    }

    public static TurmaDisciplina ToDomain(TurmaDisciplinaEntity entity)
    {
        var turmaDisciplina = new TurmaDisciplina
        {
            IdTurmaDisciplina = entity.IdTurmaDisciplina,
            IdTurma = entity.IdTurma,
      IdDisciplina = entity.IdDisciplina,
            ProfessorNome = entity.ProfessorNome
        };

        // Map navigation properties if loaded
        if (entity.Turma != null)
        {
  turmaDisciplina.Turma = TurmaMapping.ToDomain(entity.Turma);
        }

        if (entity.Disciplina != null)
        {
   turmaDisciplina.Disciplina = DisciplinaMapping.ToDomain(entity.Disciplina);
        }

        return turmaDisciplina;
    }
}
