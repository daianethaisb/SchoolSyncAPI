using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Mappings;
using SchoolSyncAPI.Application.UseCases.Turma;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmasController : ControllerBase
{
  private readonly GetAllTurmasUseCase _getAllUseCase;
 private readonly GetTurmaByIdUseCase _getByIdUseCase;
 private readonly GetTurmasByAnoLetivoUseCase _getByAnoUseCase;
    private readonly CreateTurmaUseCase _createUseCase;
 private readonly UpdateTurmaUseCase _updateUseCase;
 private readonly DeleteTurmaUseCase _deleteUseCase;

    public TurmasController(GetAllTurmasUseCase getAllUseCase, GetTurmaByIdUseCase getByIdUseCase,
        GetTurmasByAnoLetivoUseCase getByAnoUseCase, CreateTurmaUseCase createUseCase,
        UpdateTurmaUseCase updateUseCase, DeleteTurmaUseCase deleteUseCase)
    {
   _getAllUseCase = getAllUseCase; _getByIdUseCase = getByIdUseCase;
   _getByAnoUseCase = getByAnoUseCase; _createUseCase = createUseCase;
        _updateUseCase = updateUseCase; _deleteUseCase = deleteUseCase;
 }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TurmaResponse>>> GetAll()
    {
    try { var turmas = await _getAllUseCase.ExecuteAsync();
 return Ok(turmas.Select(TurmaMappingProfile.ToResponse)); }
    catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar turmas", error = ex.Message }); }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TurmaResponse>> GetById(int id)
    {
        try { var turma = await _getByIdUseCase.ExecuteAsync(id);
            if (turma == null) return NotFound(new { message = "Turma não encontrada" });
    return Ok(TurmaMappingProfile.ToResponse(turma)); }
 catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar turma", error = ex.Message }); }
    }

 [HttpGet("ano/{ano}")]
 public async Task<ActionResult<IEnumerable<TurmaResponse>>> GetByAno(int ano)
    {
        try { var turmas = await _getByAnoUseCase.ExecuteAsync(ano);
       return Ok(turmas.Select(TurmaMappingProfile.ToResponse)); }
   catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar turmas", error = ex.Message }); }
    }

  [HttpPost]
    public async Task<ActionResult<TurmaResponse>> Create([FromBody] CreateTurmaRequest request)
    {
        try { if (!ModelState.IsValid) return BadRequest(ModelState);
  var input = TurmaMappingProfile.ToInput(request);
var turma = await _createUseCase.ExecuteAsync(input);
            var response = TurmaMappingProfile.ToResponse(turma);
        return CreatedAtAction(nameof(GetById), new { id = turma.IdTurma }, response); }
        catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao criar turma", error = ex.Message }); }
    }

  [HttpPut("{id}")]
  public async Task<ActionResult> Update(int id, [FromBody] UpdateTurmaRequest request)
    {
try { if (!ModelState.IsValid) return BadRequest(ModelState);
            var input = TurmaMappingProfile.ToUpdateInput(request, id);
  await _updateUseCase.ExecuteAsync(input); return NoContent(); }
  catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao atualizar turma", error = ex.Message }); }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try { await _deleteUseCase.ExecuteAsync(id); return NoContent(); }
catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao excluir turma", error = ex.Message }); }
    }
}
