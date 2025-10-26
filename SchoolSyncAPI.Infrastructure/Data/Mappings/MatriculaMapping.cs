using SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Mappings;

public static class MatriculaMapping
{
    public static MatriculaEntity ToEntity(Matricula model)
    {
        return new MatriculaEntity
     {
   IdMatricula = model.IdMatricula,
   IdAluno = model.IdAluno,
      IdTurma = model.IdTurma,
          DataMatricula = model.DataMatricula,
  NumeroMatricula = model.NumeroMatricula,
    Situacao = model.Situacao,
            ValorMensalidade = model.ValorMensalidade,
       DiaVencimento = model.DiaVencimento,
  Observacoes = model.Observacoes,
  DataCadastro = model.DataCadastro
   };
    }

    public static Matricula ToDomain(MatriculaEntity entity)
    {
        var matricula = new Matricula
      {
            IdMatricula = entity.IdMatricula,
            IdAluno = entity.IdAluno,
   IdTurma = entity.IdTurma,
   DataMatricula = entity.DataMatricula,
        NumeroMatricula = entity.NumeroMatricula,
 Situacao = entity.Situacao,
        ValorMensalidade = entity.ValorMensalidade,
            DiaVencimento = entity.DiaVencimento,
    Observacoes = entity.Observacoes,
   DataCadastro = entity.DataCadastro
        };

        // Map navigation properties if loaded
   if (entity.Aluno != null)
        {
        matricula.Aluno = AlunoMapping.ToDomain(entity.Aluno);
    }

        if (entity.Turma != null)
        {
 matricula.Turma = TurmaMapping.ToDomain(entity.Turma);
     }

        return matricula;
    }
}
