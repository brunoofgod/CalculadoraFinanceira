using CalculadoraFinanceira.Application.Services.Calculos.Dtos;
using CalculadoraFinanceira.CrossCutting.Consts;
using CalculadoraFinanceira.CrossCutting.Extensions;
using FluentValidation;
using System;

namespace CalculadoraFinanceira.Application.Services.Calculos
{
    public class CalculoServices : ICalculoServices
    {
        private readonly IValidator<JurosCompostosDto> _jurosCompostosValidator;

        public CalculoServices(IValidator<JurosCompostosDto> jurosCompostosValidator)
        {
            _jurosCompostosValidator = jurosCompostosValidator;
        }

        public JurosCompostosDto JurosCompostos(JurosCompostosDto dto)
        {
            if (!dto.Validar(_jurosCompostosValidator).IsValid) return dto;

            dto.ValorFinal = CalularJurosCompostos(dto.ValorInicial, dto.Meses).Truncar(2);

            return dto;
        }

        private decimal CalularJurosCompostos(double valorInicial, int meses) => (decimal)(valorInicial * Math.Pow(Constantes.FatorDeJuros, meses));
    }
}