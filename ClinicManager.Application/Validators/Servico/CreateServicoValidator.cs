using ClinicManager.Application.DTOs.Servico;
using FluentValidation;

namespace ClinicManager.Application.Validators.Servico
{
    public class CreateServicoValidator : AbstractValidator<ServicoDTO>
    {
        public CreateServicoValidator()
        {
            RuleFor(s => s.Nome)
           .NotEmpty()
           .WithMessage("O nome do serviço é obrigatório.");

            RuleFor(s => s.Descricao)
                .NotEmpty()
                .WithMessage("A descrição do serviço é obrigatória.");

            RuleFor(s => s.Valor)
                .GreaterThan(0)
                .WithMessage("O valor do serviço deve ser maior que zero.");

            RuleFor(s => s.Duracao)
                .GreaterThan(0)
                .WithMessage("A duração do serviço deve ser maior que zero.");
        }
    }
}
