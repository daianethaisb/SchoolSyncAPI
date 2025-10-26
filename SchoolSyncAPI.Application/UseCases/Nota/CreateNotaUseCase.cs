using SchoolSyncAPI.Domain.Interfaces;
using DomainModels = SchoolSyncAPI.Domain.Models;
using SchoolSyncAPI.Application.UseCases.Nota.Inputs;

namespace SchoolSyncAPI.Application.UseCases.Nota;

public class CreateNotaUseCase
{
    private readonly INotaRepository _repository;
  private readonly IMatriculaRepository _matriculaRepository;
    private readonly IDisciplinaRepository _disciplinaRepository;

    public CreateNotaUseCase(
        INotaRepository repository,
        IMatriculaRepository matriculaRepository,
        IDisciplinaRepository disciplinaRepository)
    {
        _repository = repository;
 _matriculaRepository = matriculaRepository;
   _disciplinaRepository = disciplinaRepository;
    }

    public async Task<DomainModels.Nota> ExecuteAsync(CreateNotaInput input)
    {
        // Validar se matrícula existe
var matricula = await _matriculaRepository.GetByIdAsync(input.IdMatricula);
  if (matricula == null)
    throw new InvalidOperationException($"Matrícula com ID {input.IdMatricula} não encontrada.");

  // Validar se disciplina existe
 var disciplina = await _disciplinaRepository.GetByIdAsync(input.IdDisciplina);
     if (disciplina == null)
       throw new InvalidOperationException($"Disciplina com ID {input.IdDisciplina} não encontrada.");

     // Validar se já existe nota para mesma matrícula/disciplina/tipo/bimestre
     var notasExistentes = await _repository.GetByMatriculaDisciplinaAsync(input.IdMatricula, input.IdDisciplina);
        if (notasExistentes.Any(n => n.TipoAvaliacao == input.TipoAvaliacao && n.Bimestre == input.Bimestre))
          throw new InvalidOperationException($"Já existe uma nota de {input.TipoAvaliacao} para esta disciplina no {input.Bimestre}º bimestre.");

   // Validar valor da nota (0 a 10)
   if (input.NotaValor.HasValue && (input.NotaValor < 0 || input.NotaValor > 10))
       throw new InvalidOperationException("A nota deve estar entre 0 e 10.");

 // Validar bimestre (1 a 4)
   if (input.Bimestre.HasValue && (input.Bimestre < 1 || input.Bimestre > 4))
      throw new InvalidOperationException("O bimestre deve estar entre 1 e 4.");

var nota = new DomainModels.Nota(
    input.IdMatricula,
      input.IdDisciplina,
     input.TipoAvaliacao,
       input.Bimestre,
     input.NotaValor,
  input.Peso ?? 1.0m,
       input.DataAvaliacao,
  input.Observacoes
        );

        if (!nota.ValidarDadosObrigatorios())
       throw new InvalidOperationException("Dados obrigatórios não preenchidos.");

        return await _repository.AddAsync(nota);
    }
}
