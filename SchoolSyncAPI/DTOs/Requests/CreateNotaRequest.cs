using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class CreateNotaRequest
{
    [Required(ErrorMessage = "ID da matrícula é obrigatório")]
    public int IdMatricula { get; set; }

    [Required(ErrorMessage = "ID da disciplina é obrigatório")]
    public int IdDisciplina { get; set; }

    [Required(ErrorMessage = "Tipo de avaliação é obrigatório")]
    [MaxLength(50)]
    public string TipoAvaliacao { get; set; } = string.Empty;

    [Range(1, 4, ErrorMessage = "Bimestre deve estar entre 1 e 4")]
    public int? Bimestre { get; set; }

    [Range(0, 10, ErrorMessage = "Nota deve estar entre 0 e 10")]
    public decimal? NotaValor { get; set; }

    [Range(0.1, 10, ErrorMessage = "Peso deve ser maior que 0")]
    public decimal? Peso { get; set; }

 public DateTime? DataAvaliacao { get; set; }

    [MaxLength(500)]
    public string? Observacoes { get; set; }
}
