using CalculadoraFinanceira.Application.Services.Calculos.Dtos;
using FluentValidation;

namespace CalculadoraFinanceira.Application.Services.Calculos.Validation
{
    public class JurosCompostosValidator : AbstractValidator<JurosCompostosDto>
    {
        public JurosCompostosValidator()
        {
            RuleFor(x => x.ValorInicial)
                .NotEqual(0)
                .WithMessage("O valor inicial deve ser maior que zero");

            RuleFor(x => x.Meses)
                .NotEqual(0)
                .WithMessage("Os mêses devem ser maior que zero")
                .GreaterThan(0)
                .WithMessage("Os mêses devem ser não podem ser negativos");
        }
    }
}