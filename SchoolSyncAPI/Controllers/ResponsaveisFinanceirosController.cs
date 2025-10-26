using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Mappings;
using SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsaveisFinanceirosController : ControllerBase
{
    private readonly GetAllResponsaveisUseCase _getAllUseCase;
    private readonly GetResponsavelByIdUseCase _getByIdUseCase;
  private readonly GetResponsavelByCpfUseCase _getByCpfUseCase;
  private readonly CreateResponsavelUseCase _createUseCase;
    private readonly UpdateResponsavelUseCase _updateUseCase;
    private readonly DeleteResponsavelUseCase _deleteUseCase;

    public ResponsaveisFinanceirosController(
      GetAllResponsaveisUseCase getAllUseCase,
        GetResponsavelByIdUseCase getByIdUseCase,
        GetResponsavelByCpfUseCase getByCpfUseCase,
        CreateResponsavelUseCase createUseCase,
        UpdateResponsavelUseCase updateUseCase,
DeleteResponsavelUseCase deleteUseCase)
    {
        _getAllUseCase = getAllUseCase;
        _getByIdUseCase = getByIdUseCase;
  _getByCpfUseCase = getByCpfUseCase;
        _createUseCase = createUseCase;
   _updateUseCase = updateUseCase;
        _deleteUseCase = deleteUseCase;
    }

    [HttpGet]
  public async Task<ActionResult<IEnumerable<ResponsavelFinanceiroResponse>>> GetAll()
    {
        try
        {
          var responsaveis = await _getAllUseCase.ExecuteAsync();
 var response = responsaveis.Select(ResponsavelFinanceiroMappingProfile.ToResponse);
 return Ok(response);
   }
  catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao buscar responsáveis financeiros", error = ex.Message });
 }
    }

    [HttpGet("{id}")]
  public async Task<ActionResult<ResponsavelFinanceiroResponse>> GetById(int id)
    {
   try
    {
         var responsavel = await _getByIdUseCase.ExecuteAsync(id);
        if (responsavel == null)
    return NotFound(new { message = "Responsável financeiro não encontrado" });

         return Ok(ResponsavelFinanceiroMappingProfile.ToResponse(responsavel));
   }
        catch (Exception ex)
        {
 return StatusCode(500, new { message = "Erro ao buscar responsável financeiro", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ResponsavelFinanceiroResponse>> Create([FromBody] CreateResponsavelRequest request)
    {
        try
        {
          if (!ModelState.IsValid)
      return BadRequest(ModelState);

   var input = ResponsavelFinanceiroMappingProfile.ToInput(request);
var responsavel = await _createUseCase.ExecuteAsync(input);
 var response = ResponsavelFinanceiroMappingProfile.ToResponse(responsavel);

            return CreatedAtAction(nameof(GetById), new { id = responsavel.IdResponsavel }, response);
        }
     catch (InvalidOperationException ex)
     {
   return BadRequest(new { message = ex.Message });
        }
  catch (Exception ex)
        {
  return StatusCode(500, new { message = "Erro ao criar responsável financeiro", error = ex.Message });
        }
    }

 [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateResponsavelRequest request)
    {
        try
      {
  if (!ModelState.IsValid)
   return BadRequest(ModelState);

   var input = ResponsavelFinanceiroMappingProfile.ToUpdateInput(request, id);
     await _updateUseCase.ExecuteAsync(input);
return NoContent();
        }
  catch (InvalidOperationException ex)
        {
         return BadRequest(new { message = ex.Message });
 }
     catch (Exception ex)
 {
            return StatusCode(500, new { message = "Erro ao atualizar responsável financeiro", error = ex.Message });
  }
    }

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
       return StatusCode(500, new { message = "Erro ao excluir responsável financeiro", error = ex.Message });
        }
    }
}
