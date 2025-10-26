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
     // Buscar matr�cula
        var matricula = await _repository.GetByIdAsync(id);
        if (matricula == null)
        {
       throw new InvalidOperationException("Matr�cula n�o encontrada.");
     }

        // Cancelar matr�cula
     matricula.Cancelar();

  // Atualizar
   await _repository.UpdateAsync(matricula);
    }
}
