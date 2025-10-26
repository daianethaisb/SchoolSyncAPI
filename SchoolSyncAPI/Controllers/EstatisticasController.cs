using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Application.UseCases.Estatistica;
using SchoolSyncAPI.Mappings;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstatisticasController : ControllerBase
{
    private readonly GetDashboardEstatisticasUseCase _getDashboardUseCase;

    public EstatisticasController(GetDashboardEstatisticasUseCase getDashboardUseCase)
    {
        _getDashboardUseCase = getDashboardUseCase;
    }

    /// <summary>
    /// Retorna as estatísticas gerais do sistema para o dashboard
    /// </summary>
    /// <returns>Estatísticas do dashboard incluindo totais, médias e detalhamento por turma e disciplina</returns>
    [HttpGet("dashboard")]
    [ProducesResponseType(typeof(DashboardEstatisticasResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DashboardEstatisticasResponse>> GetDashboard()
    {
        try
        {
            var output = await _getDashboardUseCase.ExecuteAsync();
            var response = EstatisticaMappingProfile.ToResponse(output);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Erro ao buscar estatísticas do dashboard",
                error = ex.Message
            });
        }
    }
}
