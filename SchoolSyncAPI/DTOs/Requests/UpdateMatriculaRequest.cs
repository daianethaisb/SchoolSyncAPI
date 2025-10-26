using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class UpdateMatriculaRequest
{
   [Required]
    public int IdAluno { get; set; }

    [Required]
    public int IdTurma { get; set; }

    [Required]
    public DateTime DataMatricula { get; set; }

  [Required]
    [MaxLength(50)]
    public string NumeroMatricula { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Situacao { get; set; } = string.Empty;

    [Range(0, 99999.99)]
    public decimal? ValorMensalidade { get; set; }

    [Range(1, 31)]
 public int? DiaVencimento { get; set; }

    public string? Observacoes { get; set; }
}
