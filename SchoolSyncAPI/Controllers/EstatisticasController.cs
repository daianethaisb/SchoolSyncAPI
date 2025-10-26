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
    /// Retorna as estat�sticas gerais do sistema para o dashboard
    /// </summary>
    /// <returns>Estat�sticas do dashboard incluindo totais, m�dias e detalhamento por turma e disciplina</returns>
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
                message = "Erro ao buscar estat�sticas do dashboard",
                error = ex.Message
            });
        }
    }
}
