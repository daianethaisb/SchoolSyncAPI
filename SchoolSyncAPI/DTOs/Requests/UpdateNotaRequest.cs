using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class UpdateNotaRequest
{
    [Range(1, 4, ErrorMessage = "Bimestre deve estar entre 1 e 4")]
    public int? Bimestre { get; set; }

    [Range(0, 10, ErrorMessage = "Nota deve estar entre 0 e 10")]
    public decimal? NotaValor { get; set; }

    [Required]
    [Range(0.1, 10, ErrorMessage = "Peso deve ser maior que 0")]
    public decimal Peso { get; set; }

    public DateTime? DataAvaliacao { get; set; }

    [MaxLength(500)]
    public string? Observacoes { get; set; }
}
