using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.Turma.Inputs;
using DomainModels = SchoolSyncAPI.Domain.Models;

namespace SchoolSyncAPI.Mappings;

public static class TurmaMappingProfile
{
    public static CreateTurmaInput ToInput(CreateTurmaRequest request) => new()
    {
      Nome = request.Nome, AnoLetivo = request.AnoLetivo, Serie = request.Serie, Turno = request.Turno,
        CapacidadeMaxima = request.CapacidadeMaxima, Sala = request.Sala, DataInicio = request.DataInicio, DataFim = request.DataFim
    };

    public static UpdateTurmaInput ToUpdateInput(UpdateTurmaRequest request, int id) => new()
    {
   IdTurma = id, Nome = request.Nome, AnoLetivo = request.AnoLetivo, Serie = request.Serie,
        Turno = request.Turno, CapacidadeMaxima = request.CapacidadeMaxima, Sala = request.Sala,
   DataInicio = request.DataInicio, DataFim = request.DataFim, Ativo = request.Ativo
    };

    public static TurmaResponse ToResponse(DomainModels.Turma model) => new()
    {
IdTurma = model.IdTurma, Nome = model.Nome, AnoLetivo = model.AnoLetivo, Serie = model.Serie,
        Turno = model.Turno, Sala = model.Sala, CapacidadeMaxima = model.CapacidadeMaxima,
        VagasDisponiveis = model.ObterVagasDisponiveis(), DataInicio = model.DataInicio, DataFim = model.DataFim, Ativo = model.Ativo
    };
}
