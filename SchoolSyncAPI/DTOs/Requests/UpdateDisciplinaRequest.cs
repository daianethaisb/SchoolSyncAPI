using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class UpdateDisciplinaRequest
{
    [Required]
    [MaxLength(100)]
  public string Nome { get; set; } = string.Empty;

  [MaxLength(20)]
    public string? Codigo { get; set; }

    [Range(1, 500)]
    public int? CargaHoraria { get; set; }

    [MaxLength(500)]
    public string? Descricao { get; set; }

    public bool Ativo { get; set; }
}
