using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Mappings;
using SchoolSyncAPI.Application.UseCases.Matricula;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculasController : ControllerBase
{
    private readonly GetAllMatriculasUseCase _getAllUseCase;
    private readonly GetMatriculaByIdUseCase _getByIdUseCase;
    private readonly GetMatriculasByAlunoUseCase _getByAlunoUseCase;
    private readonly CreateMatriculaUseCase _createUseCase;
    private readonly UpdateMatriculaUseCase _updateUseCase;
    private readonly CancelarMatriculaUseCase _cancelarUseCase;

    public MatriculasController(GetAllMatriculasUseCase getAllUseCase, GetMatriculaByIdUseCase getByIdUseCase,
        GetMatriculasByAlunoUseCase getByAlunoUseCase, CreateMatriculaUseCase createUseCase,
        UpdateMatriculaUseCase updateUseCase, CancelarMatriculaUseCase cancelarUseCase)
    {
        _getAllUseCase = getAllUseCase; _getByIdUseCase = getByIdUseCase;
        _getByAlunoUseCase = getByAlunoUseCase; _createUseCase = createUseCase;
        _updateUseCase = updateUseCase; _cancelarUseCase = cancelarUseCase;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatriculaResponse>>> GetAll()
    {
        try
        {
            var matriculas = await _getAllUseCase.ExecuteAsync();
            return Ok(matriculas.Select(MatriculaMappingProfile.ToResponse));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar matrículas", error = ex.Message }); }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MatriculaResponse>> GetById(int id)
    {
        try
        {
            var matricula = await _getByIdUseCase.ExecuteAsync(id);
            if (matricula == null) return NotFound(new { message = "Matrícula não encontrada" });
            return Ok(MatriculaMappingProfile.ToResponse(matricula));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar matrícula", error = ex.Message }); }
    }

    [HttpGet("aluno/{idAluno}")]
    public async Task<ActionResult<IEnumerable<MatriculaResponse>>> GetByAluno(int idAluno)
    {
        try
        {
            var matriculas = await _getByAlunoUseCase.ExecuteAsync(idAluno);
            return Ok(matriculas.Select(MatriculaMappingProfile.ToResponse));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar matrículas", error = ex.Message }); }
    }

    [HttpPost]
    public async Task<ActionResult<MatriculaResponse>> Create([FromBody] CreateMatriculaRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var input = MatriculaMappingProfile.ToInput(request);
            var matricula = await _createUseCase.ExecuteAsync(input);
            var response = MatriculaMappingProfile.ToResponse(matricula);
            return CreatedAtAction(nameof(GetById), new { id = matricula.IdMatricula }, response);
        }
        catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao criar matrícula", error = ex.Message }); }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateMatriculaRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var input = MatriculaMappingProfile.ToUpdateInput(request, id);
            await _updateUseCase.ExecuteAsync(input); return NoContent();
        }
        catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao atualizar matrícula", error = ex.Message }); }
    }

    [HttpPatch("{id}/cancelar")]
    public async Task<ActionResult> Cancelar(int id)
    {
        try { await _cancelarUseCase.ExecuteAsync(id); return NoContent(); }
        catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao cancelar matrícula", error = ex.Message }); }
    }
}
