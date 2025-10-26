using System.ComponentModel.DataAnnotations;

namespace SchoolSyncAPI.DTOs.Requests;

public class AtualizarProfessorRequest
{
    [MaxLength(200)]
    public string? ProfessorNome { get; set; }
}
