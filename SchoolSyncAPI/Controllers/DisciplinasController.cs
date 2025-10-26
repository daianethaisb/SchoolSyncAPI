using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Mappings;
using SchoolSyncAPI.Application.UseCases.Disciplina;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisciplinasController : ControllerBase
{
    private readonly GetAllDisciplinasUseCase _getAllUseCase;
    private readonly GetDisciplinaByIdUseCase _getByIdUseCase;
  private readonly GetDisciplinasAtivasUseCase _getAtivasUseCase;
    private readonly CreateDisciplinaUseCase _createUseCase;
  private readonly UpdateDisciplinaUseCase _updateUseCase;
 private readonly DeleteDisciplinaUseCase _deleteUseCase;

    public DisciplinasController(
        GetAllDisciplinasUseCase getAllUseCase,
        GetDisciplinaByIdUseCase getByIdUseCase,
        GetDisciplinasAtivasUseCase getAtivasUseCase,
        CreateDisciplinaUseCase createUseCase,
        UpdateDisciplinaUseCase updateUseCase,
        DeleteDisciplinaUseCase deleteUseCase)
    {
        _getAllUseCase = getAllUseCase;
   _getByIdUseCase = getByIdUseCase;
        _getAtivasUseCase = getAtivasUseCase;
     _createUseCase = createUseCase;
   _updateUseCase = updateUseCase;
      _deleteUseCase = deleteUseCase;
 }

    /// <summary>
/// Lista todas as disciplinas
/// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DisciplinaResponse>>> GetAll()
    {
     try
        {
            var disciplinas = await _getAllUseCase.ExecuteAsync();
  var response = disciplinas.Select(DisciplinaMappingProfile.ToResponse);
   return Ok(response);
 }
   catch (Exception ex)
   {
         return StatusCode(500, new { message = "Erro ao buscar disciplinas", error = ex.Message });
  }
    }

    /// <summary>
 /// Lista apenas disciplinas ativas
    /// </summary>
    [HttpGet("ativas")]
 public async Task<ActionResult<IEnumerable<DisciplinaResponse>>> GetAtivas()
    {
 try
  {
     var disciplinas = await _getAtivasUseCase.ExecuteAsync();
 var response = disciplinas.Select(DisciplinaMappingProfile.ToResponse);
    return Ok(response);
 }
  catch (Exception ex)
  {
   return StatusCode(500, new { message = "Erro ao buscar disciplinas ativas", error = ex.Message });
 }
    }

    /// <summary>
 /// Busca disciplina por ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<DisciplinaResponse>> GetById(int id)
    {
    try
   {
      var disciplina = await _getByIdUseCase.ExecuteAsync(id);
       if (disciplina == null)
     return NotFound(new { message = $"Disciplina com ID {id} não encontrada." });

  return Ok(DisciplinaMappingProfile.ToResponse(disciplina));
        }
   catch (Exception ex)
  {
       return StatusCode(500, new { message = "Erro ao buscar disciplina", error = ex.Message });
     }
    }

    /// <summary>
    /// Cria uma nova disciplina
  /// </summary>
    [HttpPost]
    public async Task<ActionResult<DisciplinaResponse>> Create([FromBody] CreateDisciplinaRequest request)
    {
   try
        {
  if (!ModelState.IsValid)
  return BadRequest(ModelState);

 var input = DisciplinaMappingProfile.ToCreateInput(request);
          var disciplina = await _createUseCase.ExecuteAsync(input);
   var response = DisciplinaMappingProfile.ToResponse(disciplina);

return CreatedAtAction(nameof(GetById), new { id = disciplina.IdDisciplina }, response);
  }
        catch (InvalidOperationException ex)
        {
    return BadRequest(new { message = ex.Message });
        }
      catch (Exception ex)
      {
  return StatusCode(500, new { message = "Erro ao criar disciplina", error = ex.Message });
      }
 }

    /// <summary>
    /// Atualiza uma disciplina
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateDisciplinaRequest request)
    {
        try
      {
      if (!ModelState.IsValid)
          return BadRequest(ModelState);

   var input = DisciplinaMappingProfile.ToUpdateInput(request, id);
       await _updateUseCase.ExecuteAsync(input);
  return NoContent();
}
     catch (InvalidOperationException ex)
 {
 return NotFound(new { message = ex.Message });
 }
  catch (Exception ex)
     {
       return StatusCode(500, new { message = "Erro ao atualizar disciplina", error = ex.Message });
        }
    }

  /// <summary>
    /// Remove uma disciplina
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _deleteUseCase.ExecuteAsync(id);
  return NoContent();
 }
 catch (InvalidOperationException ex)
        {
       return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
   {
            return StatusCode(500, new { message = "Erro ao excluir disciplina", error = ex.Message });
        }
}
}
