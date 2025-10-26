using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Mappings;
using SchoolSyncAPI.Application.UseCases.Aluno;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly GetAllAlunosUseCase _getAllUseCase;
    private readonly GetAlunoByIdUseCase _getByIdUseCase;
  private readonly GetAlunosByResponsavelUseCase _getByResponsavelUseCase;
    private readonly CreateAlunoUseCase _createUseCase;
    private readonly UpdateAlunoUseCase _updateUseCase;
  private readonly DeleteAlunoUseCase _deleteUseCase;

    public AlunosController(GetAllAlunosUseCase getAllUseCase, GetAlunoByIdUseCase getByIdUseCase,
        GetAlunosByResponsavelUseCase getByResponsavelUseCase, CreateAlunoUseCase createUseCase,
UpdateAlunoUseCase updateUseCase, DeleteAlunoUseCase deleteUseCase)
    {
        _getAllUseCase = getAllUseCase; _getByIdUseCase = getByIdUseCase;
 _getByResponsavelUseCase = getByResponsavelUseCase; _createUseCase = createUseCase;
   _updateUseCase = updateUseCase; _deleteUseCase = deleteUseCase;
 }

 [HttpGet]
    public async Task<ActionResult<IEnumerable<AlunoResponse>>> GetAll()
    {
        try { var alunos = await _getAllUseCase.ExecuteAsync();
 return Ok(alunos.Select(AlunoMappingProfile.ToResponse)); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar alunos", error = ex.Message }); }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlunoResponse>> GetById(int id)
   {
      try { var aluno = await _getByIdUseCase.ExecuteAsync(id);
     if (aluno == null) return NotFound(new { message = "Aluno não encontrado" });
   return Ok(AlunoMappingProfile.ToResponse(aluno)); }
  catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar aluno", error = ex.Message }); }
    }

    [HttpGet("responsavel/{idResponsavel}")]
    public async Task<ActionResult<IEnumerable<AlunoResponse>>> GetByResponsavel(int idResponsavel)
    {
 try { var alunos = await _getByResponsavelUseCase.ExecuteAsync(idResponsavel);
        return Ok(alunos.Select(AlunoMappingProfile.ToResponse)); }
      catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar alunos", error = ex.Message }); }
    }

    [HttpPost]
 public async Task<ActionResult<AlunoResponse>> Create([FromBody] CreateAlunoRequest request)
    {
  try { if (!ModelState.IsValid) return BadRequest(ModelState);
  var input = AlunoMappingProfile.ToInput(request);
var aluno = await _createUseCase.ExecuteAsync(input);
    var response = AlunoMappingProfile.ToResponse(aluno);
   return CreatedAtAction(nameof(GetById), new { id = aluno.IdAluno }, response); }
        catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao criar aluno", error = ex.Message }); }
    }

[HttpPut("{id}")]
  public async Task<ActionResult> Update(int id, [FromBody] UpdateAlunoRequest request)
   {
 try { if (!ModelState.IsValid) return BadRequest(ModelState);
   var input = AlunoMappingProfile.ToUpdateInput(request, id);
await _updateUseCase.ExecuteAsync(input); return NoContent(); }
 catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
  catch (Exception ex) { return StatusCode(500, new { message = "Erro ao atualizar aluno", error = ex.Message }); }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try { await _deleteUseCase.ExecuteAsync(id); return NoContent(); }
        catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao excluir aluno", error = ex.Message }); }
    }
}
