using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class CreateMatriculaRequest
{
  [Required(ErrorMessage = "Aluno é obrigatório")]
    public int IdAluno { get; set; }

 [Required(ErrorMessage = "Turma é obrigatória")]
    public int IdTurma { get; set; }

    public DateTime DataMatricula { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Número de matrícula é obrigatório")]
    [MaxLength(50)]
    public string NumeroMatricula { get; set; } = string.Empty;

    [Range(0, 99999.99)]
    public decimal? ValorMensalidade { get; set; }

    [Range(1, 31, ErrorMessage = "Dia de vencimento deve estar entre 1 e 31")]
    public int? DiaVencimento { get; set; }

    public string? Observacoes { get; set; }
}
