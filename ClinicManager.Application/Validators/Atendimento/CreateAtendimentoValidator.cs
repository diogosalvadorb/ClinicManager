using ClinicManager.Application.DTOs.Atendimento;
using FluentValidation;

namespace ClinicManager.Application.Validators.Atendimento
{
    public class CreateAtendimentoValidator : AbstractValidator<AtendimentoDTO>
    {
        public CreateAtendimentoValidator()
        {
            RuleFor(a => a.Convenio)
              .NotEmpty()
              .WithMessage("Convênio é obrigatório!");

            RuleFor(a => a.DataInicio)
                .NotEmpty()
                .WithMessage("Data de Início é obrigatória!");

            RuleFor(a => a.DataFim)
                .NotEmpty()
                .WithMessage("Data de Fim é obrigatória!")
                .GreaterThanOrEqualTo(a => a.DataInicio)
                .WithMessage("A Data de Fim deve ser posterior à Data de Início.");

            RuleFor(a => a.TipoAtendimento)
                .IsInEnum()
                .WithMessage("Tipo de Atendimento inválido!");
        }
    }
}
