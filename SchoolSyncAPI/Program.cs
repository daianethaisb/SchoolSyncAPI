using Microsoft.EntityFrameworkCore;
using SchoolSyncAPI.Infrastructure.Data.Contexts;
using SchoolSyncAPI.Infrastructure.Data.Repositories;
using SchoolSyncAPI.Domain.Interfaces;
using SchoolSyncAPI.Application.UseCases.ResponsavelFinanceiro;
using SchoolSyncAPI.Application.UseCases.Aluno;
using SchoolSyncAPI.Application.UseCases.Turma;
using SchoolSyncAPI.Application.UseCases.Matricula;
using SchoolSyncAPI.Application.UseCases.Disciplina;
using SchoolSyncAPI.Application.UseCases.TurmaDisciplina;
using SchoolSyncAPI.Application.UseCases.Nota;
using SchoolSyncAPI.Application.UseCases.Estatistica;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
      .AllowAnyMethod()
       .AllowAnyHeader();
    });
});

// Configurar DbContext com InMemory Database
builder.Services.AddDbContext<SchoolSyncDbContext>(options =>
    options.UseInMemoryDatabase("SchoolSyncDb"));

// Registrar Repositórios
builder.Services.AddScoped<IResponsavelFinanceiroRepository, ResponsavelFinanceiroRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
builder.Services.AddScoped<ITurmaDisciplinaRepository, TurmaDisciplinaRepository>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();

// Registrar UseCases - ResponsavelFinanceiro
builder.Services.AddScoped<GetAllResponsaveisUseCase>();
builder.Services.AddScoped<GetResponsavelByIdUseCase>();
builder.Services.AddScoped<GetResponsavelByCpfUseCase>();
builder.Services.AddScoped<CreateResponsavelUseCase>();
builder.Services.AddScoped<UpdateResponsavelUseCase>();
builder.Services.AddScoped<DeleteResponsavelUseCase>();

// Registrar UseCases - Aluno
builder.Services.AddScoped<GetAllAlunosUseCase>();
builder.Services.AddScoped<GetAlunoByIdUseCase>();
builder.Services.AddScoped<GetAlunosByResponsavelUseCase>();
builder.Services.AddScoped<CreateAlunoUseCase>();
builder.Services.AddScoped<UpdateAlunoUseCase>();
builder.Services.AddScoped<DeleteAlunoUseCase>();

// Registrar UseCases - Turma
builder.Services.AddScoped<GetAllTurmasUseCase>();
builder.Services.AddScoped<GetTurmaByIdUseCase>();
builder.Services.AddScoped<GetTurmasByAnoLetivoUseCase>();
builder.Services.AddScoped<CreateTurmaUseCase>();
builder.Services.AddScoped<UpdateTurmaUseCase>();
builder.Services.AddScoped<DeleteTurmaUseCase>();

// Registrar UseCases - Matricula
builder.Services.AddScoped<GetAllMatriculasUseCase>();
builder.Services.AddScoped<GetMatriculaByIdUseCase>();
builder.Services.AddScoped<GetMatriculasByAlunoUseCase>();
builder.Services.AddScoped<CreateMatriculaUseCase>();
builder.Services.AddScoped<UpdateMatriculaUseCase>();
builder.Services.AddScoped<CancelarMatriculaUseCase>();

// Registrar UseCases - Disciplina
builder.Services.AddScoped<GetAllDisciplinasUseCase>();
builder.Services.AddScoped<GetDisciplinaByIdUseCase>();
builder.Services.AddScoped<GetDisciplinaByCodigoUseCase>();
builder.Services.AddScoped<GetDisciplinasAtivasUseCase>();
builder.Services.AddScoped<CreateDisciplinaUseCase>();
builder.Services.AddScoped<UpdateDisciplinaUseCase>();
builder.Services.AddScoped<DeleteDisciplinaUseCase>();

// Registrar UseCases - TurmaDisciplina
builder.Services.AddScoped<VincularDisciplinaTurmaUseCase>();
builder.Services.AddScoped<DesvincularDisciplinaTurmaUseCase>();
builder.Services.AddScoped<GetDisciplinasDaTurmaUseCase>();
builder.Services.AddScoped<GetTurmasDaDisciplinaUseCase>();
builder.Services.AddScoped<AtualizarProfessorDisciplinaUseCase>();

// Registrar UseCases - Nota
builder.Services.AddScoped<GetAllNotasUseCase>();
builder.Services.AddScoped<GetNotaByIdUseCase>();
builder.Services.AddScoped<GetNotasByMatriculaUseCase>();
builder.Services.AddScoped<GetNotasByBimestreUseCase>();
builder.Services.AddScoped<GetNotasByMatriculaDisciplinaUseCase>();
builder.Services.AddScoped<GetBoletimAlunoUseCase>();
builder.Services.AddScoped<CalcularMediaBimestreUseCase>();
builder.Services.AddScoped<CalcularMediaFinalUseCase>();
builder.Services.AddScoped<CreateNotaUseCase>();
builder.Services.AddScoped<UpdateNotaUseCase>();
builder.Services.AddScoped<DeleteNotaUseCase>();

// Registrar UseCases - Estatistica
builder.Services.AddScoped<GetDashboardEstatisticasUseCase>();

// Adicionar Controllers
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "SchoolSync API",
        Version = "v1",
        Description = "API de Gestão Escolar usando DDD e Clean Architecture"
    });
});

var app = builder.Build();

// Garantir que o banco seja criado e populado
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SchoolSyncDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
