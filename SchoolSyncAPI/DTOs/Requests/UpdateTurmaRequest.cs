using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class UpdateTurmaRequest
{
    [Required]
  [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

[Required]
    [Range(2000, 2100)]
    public int AnoLetivo { get; set; }

    [Required]
 [MaxLength(50)]
 public string Serie { get; set; } = string.Empty;

[Required]
  [MaxLength(20)]
    public string Turno { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Sala { get; set; }

    [Range(1, 100)]
    public int CapacidadeMaxima { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public bool Ativo { get; set; } = true;
}
