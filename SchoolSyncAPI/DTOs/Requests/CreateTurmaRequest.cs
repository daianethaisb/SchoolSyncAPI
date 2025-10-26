using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class CreateTurmaRequest
{
    [Required(ErrorMessage = "Nome é obrigatório")]
 [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ano letivo é obrigatório")]
    [Range(2000, 2100, ErrorMessage = "Ano letivo inválido")]
    public int AnoLetivo { get; set; }

    [Required(ErrorMessage = "Série é obrigatória")]
  [MaxLength(50)]
    public string Serie { get; set; } = string.Empty;

    [Required(ErrorMessage = "Turno é obrigatório")]
    [MaxLength(20)]
    public string Turno { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Sala { get; set; }

    [Range(1, 100, ErrorMessage = "Capacidade deve estar entre 1 e 100")]
    public int CapacidadeMaxima { get; set; } = 30;

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }
}
