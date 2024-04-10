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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json")
    .Build();

var chaveSecreta = configuration["Jwt:Key"];


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ClinicManager");
builder.Services.AddDbContext<ClinicManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ClinicManager - API", Version = "v1" });

    var securitySchems = new OpenApiSecurityScheme
    {
        Name = "JWT Autenticação",
        Description = "Entre com o JWT Bearer Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchems);
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securitySchems, new string[] { } }
            });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "ClinicManager",
        ValidAudience = "ClinicManager",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
    };
});

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
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
