using Microsoft.AspNetCore.Mvc;
using SchoolSyncAPI.DTOs.Requests;
using SchoolSyncAPI.DTOs.Responses;
using SchoolSyncAPI.Mappings;
using SchoolSyncAPI.Application.UseCases.Nota;

namespace SchoolSyncAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotasController : ControllerBase
{
    private readonly GetAllNotasUseCase _getAllUseCase;
    private readonly GetNotaByIdUseCase _getByIdUseCase;
    private readonly GetNotasByMatriculaUseCase _getByMatriculaUseCase;
    private readonly GetNotasByMatriculaDisciplinaUseCase _getByMatriculaDisciplinaUseCase;
    private readonly GetNotasByBimestreUseCase _getByBimestreUseCase;
    private readonly GetBoletimAlunoUseCase _getBoletimUseCase;
    private readonly CalcularMediaBimestreUseCase _calcularMediaBimestreUseCase;
    private readonly CalcularMediaFinalUseCase _calcularMediaFinalUseCase;
    private readonly CreateNotaUseCase _createUseCase;
    private readonly UpdateNotaUseCase _updateUseCase;
    private readonly DeleteNotaUseCase _deleteUseCase;

    public NotasController(GetAllNotasUseCase getAllUseCase, GetNotaByIdUseCase getByIdUseCase,
        GetNotasByMatriculaUseCase getByMatriculaUseCase, GetNotasByMatriculaDisciplinaUseCase getByMatriculaDisciplinaUseCase,
        GetNotasByBimestreUseCase getByBimestreUseCase, GetBoletimAlunoUseCase getBoletimUseCase,
  CalcularMediaBimestreUseCase calcularMediaBimestreUseCase, CalcularMediaFinalUseCase calcularMediaFinalUseCase,
        CreateNotaUseCase createUseCase, UpdateNotaUseCase updateUseCase, DeleteNotaUseCase deleteUseCase)
    {
        _getAllUseCase = getAllUseCase; _getByIdUseCase = getByIdUseCase; _getByMatriculaUseCase = getByMatriculaUseCase;
        _getByMatriculaDisciplinaUseCase = getByMatriculaDisciplinaUseCase; _getByBimestreUseCase = getByBimestreUseCase;
        _getBoletimUseCase = getBoletimUseCase; _calcularMediaBimestreUseCase = calcularMediaBimestreUseCase;
        _calcularMediaFinalUseCase = calcularMediaFinalUseCase; _createUseCase = createUseCase;
        _updateUseCase = updateUseCase; _deleteUseCase = deleteUseCase;
    }

    /// <summary>Lista todas as notas</summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotaDetalhadaResponse>>> GetAll()
    {
        try
        {
            var notas = await _getAllUseCase.ExecuteAsync();
            return Ok(notas.Select(NotaMappingProfile.ToDetalhadaResponse));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar notas", error = ex.Message }); }
    }

    /// <summary>Busca nota por ID</summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<NotaDetalhadaResponse>> GetById(int id)
    {
        try
        {
            var nota = await _getByIdUseCase.ExecuteAsync(id);
            if (nota == null) return NotFound(new { message = $"Nota com ID {id} não encontrada." });
            return Ok(NotaMappingProfile.ToDetalhadaResponse(nota));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar nota", error = ex.Message }); }
    }

    /// <summary>Lista todas as notas de uma matrícula</summary>
    [HttpGet("matricula/{idMatricula}")]
    public async Task<ActionResult<IEnumerable<NotaDetalhadaResponse>>> GetByMatricula(int idMatricula)
    {
        try
        {
            var notas = await _getByMatriculaUseCase.ExecuteAsync(idMatricula);
            return Ok(notas.Select(NotaMappingProfile.ToDetalhadaResponse));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar notas", error = ex.Message }); }
    }

    /// <summary>Lista notas de uma matrícula em uma disciplina específica</summary>
    [HttpGet("matricula/{idMatricula}/disciplina/{idDisciplina}")]
    public async Task<ActionResult<IEnumerable<NotaDetalhadaResponse>>> GetByMatriculaDisciplina(int idMatricula, int idDisciplina)
    {
        try
        {
            var notas = await _getByMatriculaDisciplinaUseCase.ExecuteAsync(idMatricula, idDisciplina);
            return Ok(notas.Select(NotaMappingProfile.ToDetalhadaResponse));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar notas", error = ex.Message }); }
    }

    /// <summary>Lista notas por bimestre</summary>
    [HttpGet("bimestre/{bimestre}")]
    public async Task<ActionResult<IEnumerable<NotaDetalhadaResponse>>> GetByBimestre(int bimestre)
    {
     if (bimestre < 1 || bimestre > 4) return BadRequest(new { message = "Bimestre deve estar entre 1 e 4." });
  try
        {
      var notas = await _getByBimestreUseCase.ExecuteAsync(bimestre);
            return Ok(notas.Select(NotaMappingProfile.ToDetalhadaResponse));
   }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao buscar notas", error = ex.Message }); }
    }

    /// <summary>Retorna o boletim completo de um aluno</summary>
    [HttpGet("boletim/{idMatricula}")]
    public async Task<ActionResult<BoletimResponse>> GetBoletim(int idMatricula)
    {
        try
        {
            var boletim = await _getBoletimUseCase.ExecuteAsync(idMatricula);
            return Ok(NotaMappingProfile.ToBoletimResponse(boletim));
        }
        catch (InvalidOperationException ex) { return NotFound(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao gerar boletim", error = ex.Message }); }
    }

    /// <summary>Calcula a média de um bimestre</summary>
    [HttpGet("media/matricula/{idMatricula}/disciplina/{idDisciplina}/bimestre/{bimestre}")]
    public async Task<ActionResult<MediaBimestreResponse>> GetMediaBimestre(int idMatricula, int idDisciplina, int bimestre)
    {
        if (bimestre < 1 || bimestre > 4) return BadRequest(new { message = "Bimestre deve estar entre 1 e 4." });
        try
        {
            var media = await _calcularMediaBimestreUseCase.ExecuteAsync(idMatricula, idDisciplina, bimestre);
            return Ok(NotaMappingProfile.ToMediaBimestreResponse(media));
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao calcular média", error = ex.Message }); }
    }

    /// <summary>Calcula a média final de uma disciplina</summary>
    [HttpGet("media-final/matricula/{idMatricula}/disciplina/{idDisciplina}")]
    public async Task<ActionResult> GetMediaFinal(int idMatricula, int idDisciplina)
    {
        try
        {
            var mediaFinal = await _calcularMediaFinalUseCase.ExecuteAsync(idMatricula, idDisciplina);
            return Ok(new { idMatricula, idDisciplina, mediaFinal });
        }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao calcular média final", error = ex.Message }); }
    }

    /// <summary>Lança uma nova nota</summary>
    [HttpPost]
    public async Task<ActionResult<NotaResponse>> Create([FromBody] CreateNotaRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var input = NotaMappingProfile.ToCreateInput(request);
            var nota = await _createUseCase.ExecuteAsync(input);
            var response = NotaMappingProfile.ToResponse(nota);
            return CreatedAtAction(nameof(GetById), new { id = nota.IdNota }, response);
        }
        catch (InvalidOperationException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao criar nota", error = ex.Message }); }
    }

    /// <summary>Atualiza uma nota existente</summary>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateNotaRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var input = NotaMappingProfile.ToUpdateInput(request, id);
            await _updateUseCase.ExecuteAsync(input); return NoContent();
        }
        catch (InvalidOperationException ex) { return NotFound(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao atualizar nota", error = ex.Message }); }
    }

    /// <summary>Remove uma nota</summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try { await _deleteUseCase.ExecuteAsync(id); return NoContent(); }
        catch (InvalidOperationException ex) { return NotFound(new { message = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { message = "Erro ao excluir nota", error = ex.Message }); }
    }
}
