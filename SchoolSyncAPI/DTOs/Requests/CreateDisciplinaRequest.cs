using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class CreateDisciplinaRequest
{
    [Required(ErrorMessage = "Nome da disciplina � obrigat�rio")]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Codigo { get; set; }

    [Range(1, 500, ErrorMessage = "Carga hor�ria deve estar entre 1 e 500 horas")]
    public int? CargaHoraria { get; set; }

    [MaxLength(500)]
    public string? Descricao { get; set; }
}
