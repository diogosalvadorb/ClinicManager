using ClinicManager.Application.DTOs.Medico;
using FluentValidation;

namespace ClinicManager.Application.Validators.Medico
{
    public class CreateMedicoValidator : AbstractValidator<MedicoDTO>
    {
        public CreateMedicoValidator()
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
                .WithMessage("Telefone é obrigatório!")
                .EmailAddress()
                .WithMessage("E-mail não válido!");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório!")
                .EmailAddress()
                .WithMessage("E-mail não válido!"); ;

            RuleFor(p => p.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatório!");

            RuleFor(p => p.TipoSanguineo)
                .NotEmpty()
                .WithMessage("Tipo Sanguíneo é obrigatório!");

            RuleFor(p => p.Endereco)
                .NotEmpty()
                .WithMessage("Endereço é obrigatório!");

            RuleFor(p => p.Especialista)
                .NotEmpty()
                .WithMessage("Especialista é obrigatório!");

            RuleFor(p => p.Registro)
                .NotEmpty()
                .WithMessage("Registro é obrigatório!");
        }
    }
}

