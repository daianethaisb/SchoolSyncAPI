using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class CreateDisciplinaRequest
{
    [Required(ErrorMessage = "Nome da disciplina é obrigatório")]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Codigo { get; set; }

    [Range(1, 500, ErrorMessage = "Carga horária deve estar entre 1 e 500 horas")]
    public int? CargaHoraria { get; set; }

    [MaxLength(500)]
    public string? Descricao { get; set; }
}
