using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Infrastructure.Data.Entities;

namespace SchoolSyncAPI.Infrastructure.Data.Contexts;

public class SchoolSyncDbContext : DbContext
{
    public SchoolSyncDbContext(DbContextOptions<SchoolSyncDbContext> options)
        : base(options) { }

  public DbSet<ResponsavelFinanceiroEntity> ResponsaveisFinanceiros { get; set; }
    public DbSet<AlunoEntity> Alunos { get; set; }
    public DbSet<TurmaEntity> Turmas { get; set; }
    public DbSet<MatriculaEntity> Matriculas { get; set; }
    public DbSet<DisciplinaEntity> Disciplinas { get; set; }
    public DbSet<TurmaDisciplinaEntity> TurmasDisciplinas { get; set; }
    public DbSet<NotaEntity> Notas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

        ConfigurarRelacionamentos(modelBuilder);
        ConfigurarIndicesUnicos(modelBuilder);
     SeedData(modelBuilder);
    }

    private void ConfigurarRelacionamentos(ModelBuilder modelBuilder)
  {
        // ResponsavelFinanceiro -> Alunos (1:N)
        modelBuilder.Entity<AlunoEntity>()
            .HasOne(a => a.ResponsavelFinanceiro)
            .WithMany(r => r.Alunos)
            .HasForeignKey(a => a.IdResponsavelFinanceiro)
          .OnDelete(DeleteBehavior.Restrict);

  // Aluno -> Matriculas (1:N)
      modelBuilder.Entity<MatriculaEntity>()
            .HasOne(m => m.Aluno)
    .WithMany(a => a.Matriculas)
.HasForeignKey(m => m.IdAluno)
  .OnDelete(DeleteBehavior.Restrict);

        // Turma -> Matriculas (1:N)
  modelBuilder.Entity<MatriculaEntity>()
    .HasOne(m => m.Turma)
            .WithMany(t => t.Matriculas)
     .HasForeignKey(m => m.IdTurma)
.OnDelete(DeleteBehavior.Restrict);

   // Turma -> TurmaDisciplinas (1:N)
        modelBuilder.Entity<TurmaDisciplinaEntity>()
        .HasOne(td => td.Turma)
            .WithMany(t => t.TurmaDisciplinas)
     .HasForeignKey(td => td.IdTurma)
        .OnDelete(DeleteBehavior.Restrict);

        // Disciplina -> TurmaDisciplinas (1:N)
        modelBuilder.Entity<TurmaDisciplinaEntity>()
   .HasOne(td => td.Disciplina)
     .WithMany(d => d.TurmaDisciplinas)
         .HasForeignKey(td => td.IdDisciplina)
    .OnDelete(DeleteBehavior.Restrict);

        // Matricula -> Notas (1:N)
        modelBuilder.Entity<NotaEntity>()
    .HasOne(n => n.Matricula)
        .WithMany(m => m.Notas)
          .HasForeignKey(n => n.IdMatricula)
            .OnDelete(DeleteBehavior.Restrict);

        // Disciplina -> Notas (1:N)
        modelBuilder.Entity<NotaEntity>()
     .HasOne(n => n.Disciplina)
      .WithMany(d => d.Notas)
            .HasForeignKey(n => n.IdDisciplina)
        .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigurarIndicesUnicos(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ResponsavelFinanceiroEntity>()
    .HasIndex(r => r.Cpf)
            .IsUnique();

    modelBuilder.Entity<AlunoEntity>()
    .HasIndex(a => a.Cpf)
.IsUnique();

        modelBuilder.Entity<MatriculaEntity>()
.HasIndex(m => m.NumeroMatricula)
       .IsUnique();

    modelBuilder.Entity<DisciplinaEntity>()
   .HasIndex(d => d.Nome)
            .IsUnique();

        modelBuilder.Entity<DisciplinaEntity>()
    .HasIndex(d => d.Codigo)
     .IsUnique();
    }

  private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Responsáveis Financeiros
    modelBuilder.Entity<ResponsavelFinanceiroEntity>().HasData(
        new ResponsavelFinanceiroEntity
 {
                IdResponsavel = 1,
       Nome = "Maria Silva Santos",
 Cpf = "12345678901",
          Rg = "MG1234567",
           DataNascimento = new DateTime(1980, 5, 15),
         Telefone = "(31) 3333-4444",
 Celular = "(31) 99999-8888",
         Email = "maria.silva@email.com",
      Cep = "30130-100",
          Logradouro = "Rua da Bahia",
                Numero = "1000",
Complemento = "Apto 501",
  Bairro = "Centro",
        Cidade = "Belo Horizonte",
    Estado = "MG",
          DataCadastro = new DateTime(2024, 1, 10),
       Ativo = true
            },
  new ResponsavelFinanceiroEntity
  {
          IdResponsavel = 2,
                Nome = "João Pedro Oliveira",
    Cpf = "98765432100",
                Rg = "MG7654321",
 DataNascimento = new DateTime(1975, 8, 20),
            Telefone = "(31) 3344-5566",
   Celular = "(31) 98888-7777",
       Email = "joao.oliveira@email.com",
       Cep = "30190-100",
                Logradouro = "Av. Afonso Pena",
             Numero = "1500",
    Bairro = "Centro",
 Cidade = "Belo Horizonte",
           Estado = "MG",
        DataCadastro = new DateTime(2024, 1, 15),
   Ativo = true
   },
            new ResponsavelFinanceiroEntity
            {
     IdResponsavel = 3,
                Nome = "Ana Paula Costa",
          Cpf = "11122233344",
         Rg = "MG9988776",
    DataNascimento = new DateTime(1985, 3, 10),
   Telefone = "(31) 3355-6677",
          Celular = "(31) 97777-6666",
  Email = "ana.costa@email.com",
              Cep = "30220-000",
      Logradouro = "Rua dos Timbiras",
      Numero = "2000",
             Complemento = "Casa",
         Bairro = "Lourdes",
    Cidade = "Belo Horizonte",
    Estado = "MG",
      DataCadastro = new DateTime(2024, 1, 20),
  Ativo = true
            }
  );

        // Seed Alunos
     modelBuilder.Entity<AlunoEntity>().HasData(
            new AlunoEntity
            {
      IdAluno = 1,
            Nome = "Carlos Eduardo Silva Santos",
            Cpf = "55566677788",
      DataNascimento = new DateTime(2010, 3, 15),
     Sexo = 'M',
Email = "carlos.eduardo@email.com",
          IdResponsavelFinanceiro = 1,
           Cep = "30130-100",
       Logradouro = "Rua da Bahia",
          Numero = "1000",
   Complemento = "Apto 501",
     Bairro = "Centro",
    Cidade = "Belo Horizonte",
       Estado = "MG",
 DataCadastro = new DateTime(2024, 1, 10),
     Ativo = true
      },
    new AlunoEntity
   {
       IdAluno = 2,
       Nome = "Beatriz Oliveira",
        Cpf = "66677788899",
    DataNascimento = new DateTime(2011, 7, 22),
           Sexo = 'F',
    Email = "beatriz.oliveira@email.com",
   IdResponsavelFinanceiro = 2,
     Cep = "30190-100",
    Logradouro = "Av. Afonso Pena",
       Numero = "1500",
         Bairro = "Centro",
      Cidade = "Belo Horizonte",
              Estado = "MG",
           DataCadastro = new DateTime(2024, 1, 15),
         Ativo = true
          },
            new AlunoEntity
            {
          IdAluno = 3,
       Nome = "Rafael Costa Mendes",
        Cpf = "77788899900",
 DataNascimento = new DateTime(2010, 11, 5),
            Sexo = 'M',
        IdResponsavelFinanceiro = 3,
     Cep = "30220-000",
 Logradouro = "Rua dos Timbiras",
                Numero = "2000",
                Complemento = "Casa",
   Bairro = "Lourdes",
        Cidade = "Belo Horizonte",
   Estado = "MG",
   NecessidadesEspeciais = "Deficiência visual parcial",
          DataCadastro = new DateTime(2024, 1, 20),
          Ativo = true
        }
        );

        // Seed Turmas
        modelBuilder.Entity<TurmaEntity>().HasData(
     new TurmaEntity
     {
        IdTurma = 1,
  Nome = "7º Ano A",
      AnoLetivo = 2024,
                Serie = "7º Ano",
    Turno = "Manhã",
           Sala = "Sala 101",
    CapacidadeMaxima = 35,
                DataInicio = new DateTime(2024, 2, 1),
                DataFim = new DateTime(2024, 12, 20),
          Ativo = true
            },
            new TurmaEntity
            {
    IdTurma = 2,
          Nome = "8º Ano B",
         AnoLetivo = 2024,
      Serie = "8º Ano",
       Turno = "Tarde",
         Sala = "Sala 202",
       CapacidadeMaxima = 30,
           DataInicio = new DateTime(2024, 2, 1),
                DataFim = new DateTime(2024, 12, 20),
     Ativo = true
   }
      );

        // Seed Disciplinas
    modelBuilder.Entity<DisciplinaEntity>().HasData(
    new DisciplinaEntity
  {
           IdDisciplina = 1,
  Nome = "Matemática",
    Codigo = "MAT",
            CargaHoraria = 200,
                Descricao = "Disciplina de Matemática - Ensino Fundamental",
      Ativo = true
         },
       new DisciplinaEntity
            {
  IdDisciplina = 2,
           Nome = "Português",
       Codigo = "POR",
       CargaHoraria = 180,
Descricao = "Disciplina de Língua Portuguesa",
  Ativo = true
      },
   new DisciplinaEntity
         {
   IdDisciplina = 3,
    Nome = "História",
           Codigo = "HIS",
       CargaHoraria = 120,
          Descricao = "Disciplina de História",
         Ativo = true
    },
            new DisciplinaEntity
 {
    IdDisciplina = 4,
        Nome = "Geografia",
                Codigo = "GEO",
        CargaHoraria = 120,
     Descricao = "Disciplina de Geografia",
       Ativo = true
            },
     new DisciplinaEntity
            {
                IdDisciplina = 5,
            Nome = "Ciências",
    Codigo = "CIE",
     CargaHoraria = 160,
         Descricao = "Disciplina de Ciências",
       Ativo = true
    }
  );

    // Seed Matrículas
        modelBuilder.Entity<MatriculaEntity>().HasData(
         new MatriculaEntity
            {
       IdMatricula = 1,
     IdAluno = 1,
        IdTurma = 1,
                DataMatricula = new DateTime(2024, 1, 25),
         NumeroMatricula = "2024001",
          Situacao = "Ativa",
          ValorMensalidade = 850.00m,
     DiaVencimento = 10,
     DataCadastro = new DateTime(2024, 1, 25)
         },
            new MatriculaEntity
    {
        IdMatricula = 2,
        IdAluno = 2,
        IdTurma = 2,
          DataMatricula = new DateTime(2024, 1, 26),
 NumeroMatricula = "2024002",
       Situacao = "Ativa",
       ValorMensalidade = 850.00m,
      DiaVencimento = 10,
     DataCadastro = new DateTime(2024, 1, 26)
            },
  new MatriculaEntity
{
           IdMatricula = 3,
   IdAluno = 3,
          IdTurma = 1,
      DataMatricula = new DateTime(2024, 1, 27),
             NumeroMatricula = "2024003",
      Situacao = "Ativa",
      ValorMensalidade = 850.00m,
     DiaVencimento = 15,
                Observacoes = "Aluno com necessidades especiais - material adaptado",
            DataCadastro = new DateTime(2024, 1, 27)
         }
        );

        // Seed TurmaDisciplinas
        modelBuilder.Entity<TurmaDisciplinaEntity>().HasData(
            // Disciplinas da Turma 1 (7º Ano A)
      new TurmaDisciplinaEntity { IdTurmaDisciplina = 1, IdTurma = 1, IdDisciplina = 1, ProfessorNome = "Prof. Roberto Almeida" },
       new TurmaDisciplinaEntity { IdTurmaDisciplina = 2, IdTurma = 1, IdDisciplina = 2, ProfessorNome = "Profa. Fernanda Lima" },
new TurmaDisciplinaEntity { IdTurmaDisciplina = 3, IdTurma = 1, IdDisciplina = 3, ProfessorNome = "Prof. Carlos Henrique" },
     new TurmaDisciplinaEntity { IdTurmaDisciplina = 4, IdTurma = 1, IdDisciplina = 4, ProfessorNome = "Profa. Juliana Martins" },
         new TurmaDisciplinaEntity { IdTurmaDisciplina = 5, IdTurma = 1, IdDisciplina = 5, ProfessorNome = "Prof. Marcos Vinícius" },
    // Disciplinas da Turma 2 (8º Ano B)
        new TurmaDisciplinaEntity { IdTurmaDisciplina = 6, IdTurma = 2, IdDisciplina = 1, ProfessorNome = "Profa. Sandra Costa" },
            new TurmaDisciplinaEntity { IdTurmaDisciplina = 7, IdTurma = 2, IdDisciplina = 2, ProfessorNome = "Prof. Lucas Barbosa" },
       new TurmaDisciplinaEntity { IdTurmaDisciplina = 8, IdTurma = 2, IdDisciplina = 3, ProfessorNome = "Profa. Patricia Souza" },
new TurmaDisciplinaEntity { IdTurmaDisciplina = 9, IdTurma = 2, IdDisciplina = 4, ProfessorNome = "Prof. Anderson Reis" },
            new TurmaDisciplinaEntity { IdTurmaDisciplina = 10, IdTurma = 2, IdDisciplina = 5, ProfessorNome = "Profa. Claudia Nogueira" }
        );

        // Seed Notas
    modelBuilder.Entity<NotaEntity>().HasData(
         // Notas do aluno Carlos (Matrícula 1 - Turma 1)
    new NotaEntity
            {
     IdNota = 1,
     IdMatricula = 1,
           IdDisciplina = 1,
      TipoAvaliacao = "Prova",
            Bimestre = 1,
       NotaValor = 8.5m,
     Peso = 2.0m,
     DataAvaliacao = new DateTime(2024, 3, 15),
                DataLancamento = new DateTime(2024, 3, 16)
   },
   new NotaEntity
  {
             IdNota = 2,
    IdMatricula = 1,
                IdDisciplina = 2,
       TipoAvaliacao = "Prova",
                Bimestre = 1,
          NotaValor = 7.5m,
          Peso = 2.0m,
                DataAvaliacao = new DateTime(2024, 3, 18),
         DataLancamento = new DateTime(2024, 3, 19)
     },
     // Notas da aluna Beatriz (Matrícula 2 - Turma 2)
          new NotaEntity
          {
  IdNota = 3,
                IdMatricula = 2,
     IdDisciplina = 1,
     TipoAvaliacao = "Prova",
          Bimestre = 1,
    NotaValor = 9.0m,
    Peso = 2.0m,
   DataAvaliacao = new DateTime(2024, 3, 15),
           DataLancamento = new DateTime(2024, 3, 16)
            },
      new NotaEntity
 {
            IdNota = 4,
  IdMatricula = 2,
       IdDisciplina = 2,
    TipoAvaliacao = "Trabalho",
      Bimestre = 1,
        NotaValor = 8.0m,
     Peso = 1.0m,
  DataAvaliacao = new DateTime(2024, 3, 20),
DataLancamento = new DateTime(2024, 3, 21)
   },
       // Notas do aluno Rafael (Matrícula 3 - Turma 1)
 new NotaEntity
            {
             IdNota = 5,
IdMatricula = 3,
     IdDisciplina = 1,
        TipoAvaliacao = "Prova",
   Bimestre = 1,
          NotaValor = 7.0m,
           Peso = 2.0m,
    DataAvaliacao = new DateTime(2024, 3, 15),
             DataLancamento = new DateTime(2024, 3, 16)
         },
            new NotaEntity
            {
    IdNota = 6,
    IdMatricula = 3,
                IdDisciplina = 3,
           TipoAvaliacao = "Seminário",
     Bimestre = 1,
          NotaValor = 8.5m,
              Peso = 1.5m,
      DataAvaliacao = new DateTime(2024, 3, 22),
       Observacoes = "Excelente apresentação",
   DataLancamento = new DateTime(2024, 3, 23)
        }
        );
    }
}
