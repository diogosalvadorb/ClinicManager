using ClinicManager.Application.DTOs.Atendimento;
using ClinicManager.Application.DTOs.Medico;
using ClinicManager.Application.DTOs.Paciente;
using ClinicManager.Application.DTOs.Servico;
using ClinicManager.Application.Services.Implementations;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Application.Validators.Atendimento;
using ClinicManager.Application.Validators.Medico;
using ClinicManager.Application.Validators.Paciente;
using ClinicManager.Application.Validators.Servico;
using ClinicManager.Core.Repositories;
using ClinicManager.Infrastructure.Persistence;
using ClinicManager.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ClinicManager");
builder.Services.AddDbContext<ClinicManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Validators
builder.Services.AddTransient<IValidator<MedicoDTO>, CreateMedicoValidator>();
builder.Services.AddTransient<IValidator<MedicoUpdateDTO>, UpdateMedicoValidator>();
builder.Services.AddTransient<IValidator<AtendimentoDTO>, CreateAtendimentoValidator>();
builder.Services.AddTransient<IValidator<AtendimentoUpdateDTO>, UpdateAtendimentoValidator>();
builder.Services.AddTransient<IValidator<PacienteDTO>, CreatePacienteValidator>();
builder.Services.AddTransient<IValidator<PacienteUpdateDTO>, UpdatePacienteValidator>();
builder.Services.AddTransient<IValidator<ServicoDTO>, CreateServicoValidator>();
builder.Services.AddTransient<IValidator<ServicoUpdateDTO>, UpdateServicoValidator>();

//Services
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IArquivoService, ArquivoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//Repository
builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
