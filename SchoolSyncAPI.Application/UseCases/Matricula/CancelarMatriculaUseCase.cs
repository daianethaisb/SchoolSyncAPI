using SchoolSyncAPI.Domain.Interfaces;

namespace SchoolSyncAPI.Application.UseCases.Matricula;

public class CancelarMatriculaUseCase
{
    private readonly IMatriculaRepository _repository;

    public CancelarMatriculaUseCase(IMatriculaRepository repository)
    {
_repository = repository;
 }

    public async Task ExecuteAsync(int id)
    {
     // Buscar matrícula
        var matricula = await _repository.GetByIdAsync(id);
        if (matricula == null)
        {
       throw new InvalidOperationException("Matrícula não encontrada.");
     }

        // Cancelar matrícula
     matricula.Cancelar();

  // Atualizar
   await _repository.UpdateAsync(matricula);
    }
}
