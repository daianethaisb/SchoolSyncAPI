using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Mappings;
using SchoolSyncAPI.Application.UseCases.TurmaDisciplina;
using SchoolSyncAPI.Application.UseCases.TurmaDisciplina.Inputs;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/turmas-disciplinas")]
public class TurmasDisciplinasController : ControllerBase
{
    private readonly VincularDisciplinaTurmaUseCase _vincularUseCase;
    private readonly DesvincularDisciplinaTurmaUseCase _desvincularUseCase;
    private readonly GetDisciplinasDaTurmaUseCase _getDisciplinasTurmaUseCase;
    private readonly GetTurmasDaDisciplinaUseCase _getTurmasDisciplinaUseCase;
    private readonly AtualizarProfessorDisciplinaUseCase _atualizarProfessorUseCase;

    public TurmasDisciplinasController(
        VincularDisciplinaTurmaUseCase vincularUseCase,
        DesvincularDisciplinaTurmaUseCase desvincularUseCase,
        GetDisciplinasDaTurmaUseCase getDisciplinasTurmaUseCase,
        GetTurmasDaDisciplinaUseCase getTurmasDisciplinaUseCase,
        AtualizarProfessorDisciplinaUseCase atualizarProfessorUseCase)
    {
        _vincularUseCase = vincularUseCase;
        _desvincularUseCase = desvincularUseCase;
        _getDisciplinasTurmaUseCase = getDisciplinasTurmaUseCase;
        _getTurmasDisciplinaUseCase = getTurmasDisciplinaUseCase;
        _atualizarProfessorUseCase = atualizarProfessorUseCase;
    }

    /// <summary>
    /// Vincula uma disciplina a uma turma
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TurmaDisciplinaResponse>> VincularDisciplina(
        [FromBody] VincularDisciplinaTurmaRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var input = TurmaDisciplinaMappingProfile.ToVincularInput(request);
            var turmaDisciplina = await _vincularUseCase.ExecuteAsync(input);
            var response = TurmaDisciplinaMappingProfile.ToResponse(turmaDisciplina);

            return CreatedAtAction(nameof(GetDisciplinasDaTurma),
    new { idTurma = turmaDisciplina.IdTurma }, response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao vincular disciplina à turma", error = ex.Message });
        }
    }

    /// <summary>
    /// Lista todas as disciplinas de uma turma específica
    /// </summary>
    [HttpGet("turma/{idTurma}")]
    public async Task<ActionResult<IEnumerable<TurmaDisciplinaDetalhadaResponse>>> GetDisciplinasDaTurma(int idTurma)
    {
        try
        {
            var turmaDisciplinas = await _getDisciplinasTurmaUseCase.ExecuteAsync(idTurma);
            var response = turmaDisciplinas.Select(TurmaDisciplinaMappingProfile.ToDetalhadaResponse);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao buscar disciplinas da turma", error = ex.Message });
        }
    }

    /// <summary>
    /// Lista todas as turmas que possuem uma disciplina específica
    /// </summary>
    [HttpGet("disciplina/{idDisciplina}")]
    public async Task<ActionResult<IEnumerable<TurmaDisciplinaDetalhadaResponse>>> GetTurmasDaDisciplina(int idDisciplina)
    {
        try
        {
            var turmaDisciplinas = await _getTurmasDisciplinaUseCase.ExecuteAsync(idDisciplina);
            var response = turmaDisciplinas.Select(TurmaDisciplinaMappingProfile.ToDetalhadaResponse);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao buscar turmas da disciplina", error = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza o professor de uma disciplina em uma turma
    /// </summary>
    [HttpPatch("{id}/professor")]
    public async Task<ActionResult> AtualizarProfessor(int id, [FromBody] AtualizarProfessorRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var input = new AtualizarProfessorInput
            {
                IdTurmaDisciplina = id,
                ProfessorNome = request.ProfessorNome
            };

            await _atualizarProfessorUseCase.ExecuteAsync(input);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao atualizar professor", error = ex.Message });
        }
    }

    /// <summary>
    /// Desvincula uma disciplina de uma turma
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Desvincular(int id)
    {
        try
        {
            await _desvincularUseCase.ExecuteAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao desvincular disciplina da turma", error = ex.Message });
        }
    }
}
