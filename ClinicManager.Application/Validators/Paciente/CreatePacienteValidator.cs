using ClinicManager.Application.DTOs.Paciente;
using FluentValidation;

namespace ClinicManager.Application.Validators.Paciente
{
    public class CreatePacienteValidator : AbstractValidator<PacienteDTO>
    {
        public CreatePacienteValidator()
        {
            RuleFor(p => p.Nome)
             .NotEmpty()
             .WithMessage("Nome é obrigatório!");

            RuleFor(p => p.SobreNome)
                .NotEmpty()
                .WithMessage("Sobrenome é obrigatório!");

            RuleFor(p => p.DataDeNascimento)
                .NotEmpty()
                .WithMessage("Data de Nascimento é obrigatória!");

            RuleFor(p => p.Telefone)
                .NotEmpty()
                .WithMessage("Telefone é obrigatório!");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório!")
                .EmailAddress()
                .WithMessage("Email inválido!");

            RuleFor(p => p.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatório!");

            RuleFor(p => p.TipoSanguineo)
                .NotEmpty()
                .WithMessage("Tipo Sanguíneo é obrigatório!");

            RuleFor(p => p.Altura)
                .GreaterThan(0)
                .WithMessage("Altura deve ser maior que zero!");

            RuleFor(p => p.Peso)
                .GreaterThan(0)
                .WithMessage("Peso deve ser maior que zero!");

            RuleFor(p => p.Endereco)
                .NotEmpty()
                .WithMessage("Endereço é obrigatório!");
        }
    }
}
